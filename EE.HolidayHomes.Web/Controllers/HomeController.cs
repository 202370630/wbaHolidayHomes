using EE.HolidayHomes.Core.Entities;
using EE.HolidayHomes.Web.Data;
using EE.HolidayHomes.Web.Models;
using EE.HolidayHomes.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EE.HolidayHomes.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var homeIndexViewModel = new HomeIndexViewModel
            {
                HolidayHomes = await _applicationDbContext
                .HolidayHomes
                .Include(h => h.Location)
                .Select(h => new HolidayHomeInfoViewModel
                {
                    Id = h.Id,
                    Name = h.Name,
                    Price = h.Price,
                    Location = new BaseViewModel
                    {
                        Id = h.Location.Id,
                        Name = h.Location.Name,
                    },
                    Image = h.Image,
                }).ToListAsync()
            };
            homeIndexViewModel.PageTitle = "Our holidayhomes";
            return View(homeIndexViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> FindbyLocation(int id)
        {
            if (!await _applicationDbContext.Locations.AnyAsync(l => l.Id == id))
            {
                return NotFound();
            }
            var homeIndexViewModel = new HomeIndexViewModel
            {
                HolidayHomes = await _applicationDbContext
                .HolidayHomes
                .Where(h => h.LocationId == id)
                .Select(h => new HolidayHomeInfoViewModel
                {
                    Id = h.Id,
                    Name = h.Name,
                    Price = h.Price,
                    Location = new BaseViewModel
                    {
                        Id = h.Location.Id,
                        Name = h.Location.Name,
                    },
                    Image = h.Image,
                }).ToListAsync()
            };
            homeIndexViewModel.PageTitle = _applicationDbContext
                .Locations.FirstOrDefault(l => l.Id == id).Name;
            return View("Index", homeIndexViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Info(int id)
        {
            if (!await _applicationDbContext.HolidayHomes.AnyAsync(h => h.Id == id))
            {
                return NotFound();
            }

            var holidayHome = await _applicationDbContext
                .HolidayHomes
                .Include(h => h.Location)
                .Include(h => h.HomeType)
                .Include(h => h.HomeProperties)
                .FirstOrDefaultAsync(h => h.Id == id);

            var holidayHomeInfoViewModel = new HolidayHomeInfoViewModel
            {
                Name = holidayHome.Name,
                Id = holidayHome.Id,

                HomeProperties = holidayHome.HomeProperties
                    .Select(p => new BaseViewModel
                    {
                        Id = p.Id,
                        Name = p.Name,
                    }),

                HomeType = new BaseViewModel
                {
                    Id = holidayHome.HomeType.Id,
                    Name = holidayHome.HomeType.Name,
                },

                Location = new BaseViewModel
                {
                    Id = holidayHome.Location.Id,
                    Name = holidayHome.Location.Name,
                },

                Price = holidayHome.Price,
                Image = holidayHome.Image,
                PageTitle = holidayHome.Name,
            };

            return View(holidayHomeInfoViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}