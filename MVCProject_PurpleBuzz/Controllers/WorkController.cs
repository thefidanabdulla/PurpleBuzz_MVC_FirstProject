using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCProject_PurpleBuzz.DAL;
using MVCProject_PurpleBuzz.ViewModel;
using MVCProject_PurpleBuzz.ViewModel.Work;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVCProject_PurpleBuzz.Controllers
{
    public class WorkController : Controller
    {
        private readonly AppDbContext _dbContext;
        public WorkController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            var components = await _dbContext.Components.ToListAsync();
            var categories = await _dbContext.Categories.Include(x => x.Components).ToListAsync();

            var vm = new WorkIndexViewModel
            {
                categories = categories,
                components = components
            };
            return View(vm);
        }
    }
}

