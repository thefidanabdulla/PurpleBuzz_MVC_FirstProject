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
        var projectComponents = await _appDbContext.ProjectComponents.ToListAsync();

        var homeRecentWorkComponent = await _appDbContext.RecentWorks.ToListAsync();
        //var homeRecentWorkComponent = new List<ProjectComponent>
        //{
        //    new ProjectComponent{Id=1, Title="Social Media", Description="Social Media Description", ImagePath="/assets/img/recent-work-01.jpg"},
        //    new ProjectComponent{Id=2, Title="Web Marketing", Description="Web Marketing Description", ImagePath="/assets/img/recent-work-02.jpg"},
        //    new ProjectComponent{Id=3, Title="R & D", Description="R & D Description", ImagePath="/assets/img/recent-work-03.jpg"},
        //    new ProjectComponent{Id=4, Title="Public Relation", Description="Public Relation Description", ImagePath="/assets/img/recent-work-04.jpg"},
        //    new ProjectComponent{Id=5, Title="Branding", Description="Branding Description", ImagePath="/assets/img/recent-work-05.jpg"},
        //    new ProjectComponent{Id=6, Title="Creative Design", Description="Creative Design Description", ImagePath="/assets/img/recent-work-06.jpg"},
        //};

        var model = new HomeIndexViewModel
        {
            ProjectComponents = projectComponents,
            HomeRecentWorkComponent = homeRecentWorkComponent
            
        };

        return View(model);
    }

    
}

