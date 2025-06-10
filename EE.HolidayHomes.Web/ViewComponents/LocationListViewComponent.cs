using EE.HolidayHomes.Web.Data;
using EE.HolidayHomes.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EE.HolidayHomes.Web.ViewComponents
{
    [ViewComponent(Name = "LocationList")]
    public class LocationListViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public LocationListViewComponent(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IViewComponentResult Invoke()
        {
            var dropdownListViewModel = new DropdownListViewModel
            {
                DropDownListItems = _applicationDbContext.Locations
                .Select(l => new BaseViewModel { Id = l.Id, Name = l.Name })
            };
            return View(dropdownListViewModel);
        }
    }
}
