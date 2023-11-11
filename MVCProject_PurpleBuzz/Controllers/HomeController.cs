using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCProject_PurpleBuzz.DAL;
using MVCProject_PurpleBuzz.Models;
using MVCProject_PurpleBuzz.ViewModel.Home;

namespace MVCProject_PurpleBuzz.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _appDbContext;

    public HomeController (AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task<IActionResult> Index()
    {
        var recentWorkComponents = await _appDbContext.RecentWorks.OrderByDescending(rcw => rcw.Id).Take(3).ToListAsync();

        var projectComponents = await _appDbContext.ProjectComponents.ToListAsync();

        var homeRecentWorkComponent = await _appDbContext.RecentWorks.ToListAsync();

        var model = new HomeIndexViewModel
        {
            ProjectComponents = projectComponents,
            HomeRecentWorkComponent = homeRecentWorkComponent,
            RecentWorks = recentWorkComponents
            
        };

        return View(model);
    }

    public async Task<IActionResult> Loadmore(int skiprow)
    {
        var recentWorkComponents = await _appDbContext.RecentWorks.OrderByDescending(rcw => rcw.Id).Skip(3 * skiprow).Take(3).ToListAsync();


        return PartialView("_RecentWorkPartialView", recentWorkComponents);
    }



}

