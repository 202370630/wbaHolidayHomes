using EE.HolidayHomes.Web.Models;

namespace EE.HolidayHomes.Web.ViewModels
{
    public class CartIndexViewModel
    {
        public List<CartItemModel> Items { get; set; }
        public decimal Total { get; set; }
    }
}
