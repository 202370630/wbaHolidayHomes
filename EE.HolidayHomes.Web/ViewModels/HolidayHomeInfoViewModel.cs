namespace EE.HolidayHomes.Web.ViewModels
{
    public class HolidayHomeInfoViewModel : BaseViewModel
    {
        public BaseViewModel HomeType { get; set; }
        public IEnumerable<BaseViewModel> HomeProperties { get; set; }
        public decimal Price { get; set; }
        public BaseViewModel Location { get; set; }
        public string Image { get; set; }
        public string PageTitle { get; set; }
    }
}
