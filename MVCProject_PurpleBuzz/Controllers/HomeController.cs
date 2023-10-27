using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCProject_PurpleBuzz.Models;

namespace MVCProject_PurpleBuzz.Controllers;

public class HomeController : Controller
{

    public IActionResult Index()
    {
        return View();
    }

    
}

