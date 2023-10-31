using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCProject_PurpleBuzz.Models;
using MVCProject_PurpleBuzz.ViewModel.Home;

namespace MVCProject_PurpleBuzz.Controllers;

public class HomeController : Controller
{

    public IActionResult Index()
    {
        var projectComponents = new List<ProjectComponent>
        {
            new ProjectComponent{Id=1, Title="UI/UX Design", Description="UI UX Description", ImagePath="/assets/img/services-01.jpg"},
            new ProjectComponent{Id=2, Title="Social Media Design", Description="Social Media Description", ImagePath="/assets/img/services-02.jpg"},
            new ProjectComponent{Id=3, Title="Marketing Design", Description="Marketing Description", ImagePath="/assets/img/services-03.jpg"},
            new ProjectComponent{Id=4, Title="Graphic Design", Description="Graphic Description", ImagePath="/assets/img/services-04.jpg"},
            new ProjectComponent{Id=5, Title="Digital Marketing Design", Description="Digital Marketing Description", ImagePath="/assets/img/services-05.jpg"},
            new ProjectComponent{Id=6, Title="Market Research Design", Description="Market Research Description", ImagePath="/assets/img/services-06.jpg"},
            new ProjectComponent{Id=7, Title="Business Design", Description="Business Description", ImagePath="/assets/img/services-07.jpg"},
            new ProjectComponent{Id=8, Title="Branding Design", Description="Branding Description", ImagePath="/assets/img/services-08.jpg"},
        };

        var homeRecentWorkComponent = new List<ProjectComponent>
        {
            new ProjectComponent{Id=1, Title="Social Media", Description="Social Media Description", ImagePath="/assets/img/recent-work-01.jpg"},
            new ProjectComponent{Id=2, Title="Web Marketing", Description="Web Marketing Description", ImagePath="/assets/img/recent-work-02.jpg"},
            new ProjectComponent{Id=3, Title="R & D", Description="R & D Description", ImagePath="/assets/img/recent-work-03.jpg"},
            new ProjectComponent{Id=4, Title="Public Relation", Description="Public Relation Description", ImagePath="/assets/img/recent-work-04.jpg"},
            new ProjectComponent{Id=5, Title="Branding", Description="Branding Description", ImagePath="/assets/img/recent-work-05.jpg"},
            new ProjectComponent{Id=6, Title="Creative Design", Description="Creative Design Description", ImagePath="/assets/img/recent-work-06.jpg"},
        };

        var model = new HomeIndexViewModel
        {
            ProjectComponents = projectComponents,
            HomeRecentWorkComponent = homeRecentWorkComponent
            
        };

        return View(model);
    }

    
}

