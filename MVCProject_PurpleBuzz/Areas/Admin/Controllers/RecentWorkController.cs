using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCProject_PurpleBuzz.DAL;
using MVCProject_PurpleBuzz.Models;

namespace MVCProject_PurpleBuzz.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RecentWorkController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public RecentWorkController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _appDbContext.RecentWorks.ToListAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RecentWork recentWork)
        {
            if (!ModelState.IsValid) return View(recentWork);

            bool isExist = await _appDbContext.RecentWorks.AnyAsync(rcw => rcw.Title == recentWork.Title);
            if (isExist)
            {
                ModelState.AddModelError("Title", "This work is already exist ");
                return View(recentWork);
            }

            await _appDbContext.RecentWorks.AddAsync(recentWork);
            await _appDbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }
    }
}
