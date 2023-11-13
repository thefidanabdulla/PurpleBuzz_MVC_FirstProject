using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCProject_PurpleBuzz.DAL;
using MVCProject_PurpleBuzz.Models;
using System.Net.Mime;

namespace MVCProject_PurpleBuzz.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamMemberController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment webHostEnvironment;

        public TeamMemberController(AppDbContext appDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _appDbContext = appDbContext;
            this.webHostEnvironment = webHostEnvironment;
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

            if (!teamMember.Photo.ContentType.Contains("image/")) {
                ModelState.AddModelError("Photo", "File must be image format");
                return View(teamMember);
            }

            if (teamMember.Photo.Length / 1024 > 300)
            {
                ModelState.AddModelError("Photo", "File size is greater than 100 kb");
                return View(teamMember);
            }

            var fileName = $"{Guid.NewGuid()}_{teamMember.Photo.FileName}";
            var path = Path.Combine(webHostEnvironment.WebRootPath, "assets","img", fileName);

            using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite ))
            {
                await teamMember.Photo.CopyToAsync(fileStream);
            }

            teamMember.PhotoName = fileName;
            await _appDbContext.AddAsync(teamMember);
            await _appDbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
