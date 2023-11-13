using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCProject_PurpleBuzz.DAL;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVCProject_PurpleBuzz.Controllers
{
    public class AboutController : Controller
    {
        

        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}

