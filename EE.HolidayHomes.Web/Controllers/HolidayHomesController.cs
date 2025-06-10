using EE.HolidayHomes.Web.Data;
using EE.HolidayHomes.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EE.HolidayHomes.Web.Controllers
{

    public class HolidayHomesController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly ILogger<HomeController> _logger;

        public HolidayHomesController(ILogger<HomeController> logger, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var holidayHomesCreateViewModel = new HolidayHomesCreateViewModel
            {
                Location = await _applicationDbContext.Locations
                .OrderBy(l => l.Name)
                .Select(l => new SelectListItem
                {
                    Text = l.Name,
                    Value = l.Id.ToString()
                }).ToListAsync(),

                HomeType = await _applicationDbContext.HomeTypes
                .OrderBy(l => l.Name)
                .Select(l => new SelectListItem
                {
                    Text = l.Name,
                    Value = l.Id.ToString()
                }).ToListAsync(),

                HomeProperties = await _applicationDbContext.HomeProperties
                .OrderBy(l => l.Name)
                .Select(l => new SelectListItem
                {
                    Text = l.Name,
                    Value = l.Id.ToString()
                }).ToListAsync(),

            };
            return View(holidayHomesCreateViewModel);
        }
    }
}
