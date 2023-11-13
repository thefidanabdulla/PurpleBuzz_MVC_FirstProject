using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCProject_PurpleBuzz.DAL;
using MVCProject_PurpleBuzz.Helpers;
using MVCProject_PurpleBuzz.Models;
using MVCProject_PurpleBuzz.ViewModel.TeamMembers;
using System.Net.Mime;

namespace MVCProject_PurpleBuzz.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamMemberController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IFileService fileService;

        public TeamMemberController(AppDbContext appDbContext, IWebHostEnvironment webHostEnvironment, IFileService fileService)
        {
            _appDbContext = appDbContext;
            this.webHostEnvironment = webHostEnvironment;
            this.fileService = fileService;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _appDbContext.TeamMembers.ToListAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TeamMember teamMember)
        {


            if (!ModelState.IsValid)
            {
                return View(teamMember);
            }

            if (!fileService.IsImage(teamMember.Photo)) {
                ModelState.AddModelError("Photo", "File must be image format");
                return View(teamMember);
            }

            if (!fileService.SizeCheck(teamMember.Photo))
            {
                ModelState.AddModelError("Photo", "File size is greater than 100 kb");
                return View(teamMember);
            }



            teamMember.PhotoName = await fileService.UploadAsync(webHostEnvironment.WebRootPath, teamMember.Photo);
            await _appDbContext.AddAsync(teamMember);
            await _appDbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _appDbContext.TeamMembers.FindAsync(id);
            if (model == null) return NotFound();

            return View(model); 
        }

        [HttpPost] 
        public async Task<IActionResult> DeleteComponent(int id)
        {
            var model = await _appDbContext.TeamMembers.FindAsync(id);
            if(model == null) return NotFound();

            fileService.Delete(webHostEnvironment.WebRootPath, model.PhotoName);

            _appDbContext.TeamMembers.Remove(model);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var dbmodel = await _appDbContext.TeamMembers.FindAsync(id);
            if (dbmodel == null) return NotFound();

            var model = new TeamMemberUpdateViewModel
            {
                Name = dbmodel.Name,
                Position = dbmodel.Position,
                PhotoName = dbmodel.PhotoName,
            };
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Update(int id, TeamMemberUpdateViewModel model)
        {
            if (!ModelState.IsValid) return View(model);


            var dbModel = await _appDbContext.TeamMembers.FindAsync(id);

            if(dbModel == null) return NotFound();

            dbModel.Name = model.Name;
            dbModel.Position = model.Position;

            if(model.Photo != null)
            {
                if (!fileService.IsImage(model.Photo))
                {
                    ModelState.AddModelError("Photo", $"{model.Photo.FileName} named file is not image");
                    return View(model);
                }
                else
                {
                    if (!fileService.SizeCheck(model.Photo))
                    {
                        ModelState.AddModelError("Photo", $"{model.Photo.FileName} named file size must be lower than 300 kb");
                        return View(model) ;
                    }

                    fileService.Delete(webHostEnvironment.WebRootPath, dbModel.PhotoName);
                    dbModel.PhotoName = await fileService.UploadAsync(webHostEnvironment.WebRootPath, model.Photo);

                }
            }
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("index");
        }
    }

}
