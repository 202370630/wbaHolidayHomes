namespace EE.HolidayHomes.Web.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<HolidayHomeInfoViewModel> HolidayHomes { get; set; }
        public string PageTitle { get; set; }
    }
}
