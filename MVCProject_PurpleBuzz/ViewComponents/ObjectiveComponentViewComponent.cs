using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCProject_PurpleBuzz.DAL;

namespace MVCProject_PurpleBuzz.ViewComponents
{
    public class ObjectiveComponentViewComponent:ViewComponent
    {
        private readonly AppDbContext _appDbContext;

        public ObjectiveComponentViewComponent(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _appDbContext.ObjectiveComponents.ToListAsync();
            return View(model);
        }
    }
}
