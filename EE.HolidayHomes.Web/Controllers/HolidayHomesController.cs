using EE.HolidayHomes.Core.Entities;
using EE.HolidayHomes.Web.Data;
using EE.HolidayHomes.Web.ViewModels;
using Microsoft.AspNetCore.Hosting;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HolidayHomesCreateViewModel holidayHomesCreateViewModel)
        {
            if (!ModelState.IsValid)
            {
                holidayHomesCreateViewModel = new HolidayHomesCreateViewModel
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
            
            var holidayHome = new HolidayHome();
            holidayHome.Name = holidayHomesCreateViewModel.Name;
            holidayHome.Name = holidayHomesCreateViewModel.Name;
            holidayHome.LocationId = holidayHomesCreateViewModel.LocationId;
            holidayHome.HomeTypeId = holidayHomesCreateViewModel.HomeTypeId;

            holidayHome.HomeProperties = await _applicationDbContext
                .HomeProperties
                .Where(p => holidayHomesCreateViewModel.HomePropertyIds.Contains(p.Id)).ToListAsync();

            
            await _applicationDbContext.HolidayHomes.AddAsync(holidayHome);
            try
            {
                await _applicationDbContext.SaveChangesAsync();
            }
            catch (DbUpdateException dbUpdateException)
            {
                Console.WriteLine(dbUpdateException.Message);
            }
            return RedirectToAction("Home", "Index");
        }
    }
}
