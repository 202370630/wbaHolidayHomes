using EE.HolidayHomes.Web.Data;
using EE.HolidayHomes.Web.Models;
using EE.HolidayHomes.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace EE.HolidayHomes.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CartController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var cartIndexViewModel = new CartIndexViewModel();
            cartIndexViewModel.Items = new List<CartItemModel>();
            if (HttpContext.Session.Keys.Contains("CartItems"))
            {
                cartIndexViewModel.Items = JsonConvert
                    .DeserializeObject<List<CartItemModel>>(HttpContext.Session.GetString("CartItems"));
            }
            cartIndexViewModel.Total = cartIndexViewModel.Items.Sum(i => i.Price * i.Quantity);
            return View(cartIndexViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Add(int id)
        {
            var holidayHome = await _applicationDbContext.HolidayHomes
                .FirstOrDefaultAsync(h => h.Id == id);
            if (holidayHome == null)
            {
                return NotFound();
            }
            var cartIndexViewModel = new CartIndexViewModel();
            cartIndexViewModel.Items = new List<CartItemModel>();
            if (HttpContext.Session.Keys.Contains("CartItems"))
            {
                cartIndexViewModel.Items = JsonConvert
                    .DeserializeObject<List<CartItemModel>>(HttpContext.Session.GetString("CartItems"));
            }
            if(cartIndexViewModel.Items.Any(i => i.Id == id))
            {
                cartIndexViewModel.Items.FirstOrDefault(i => i.Id == id)
                    .Quantity++;
            }
            else
            {
                cartIndexViewModel.Items.Add(new CartItemModel
                {
                    Id = holidayHome.Id,
                    Name = holidayHome.Name,
                    Price = holidayHome.Price,
                    Quantity = 1,
                });
            }
            HttpContext.Session.SetString("CartItems", JsonConvert.SerializeObject(cartIndexViewModel.Items));
            HttpContext.Session.SetInt32("NumOfItems", cartIndexViewModel.Items.Sum(i => i.Quantity));
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Remove(int id)
        {
            //Remove item from cart
            return RedirectToAction("Index");
        }
    }
}
