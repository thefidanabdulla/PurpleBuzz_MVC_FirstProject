using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCProject_PurpleBuzz.DAL;

namespace MVCProject_PurpleBuzz.Controllers
{
    public class RecentWorkController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public RecentWorkController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IActionResult> Index()
        {
         
            return View();
            //return View(recentWorkComponents);
        }
    }
}
