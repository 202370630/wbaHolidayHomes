using Microsoft.AspNetCore.Mvc;

namespace EE.HolidayHomes.Web.Controllers
{
    public class HolidayHomesController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
