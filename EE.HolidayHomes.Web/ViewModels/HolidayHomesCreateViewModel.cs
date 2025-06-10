using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace EE.HolidayHomes.Web.ViewModels
{
    public class HolidayHomesCreateViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }


        public IEnumerable<SelectListItem> Location { get; set; }
        [Display(Name = "Locations")]
        public int LocationId { get; set; }

        public IEnumerable<SelectListItem> HomeType { get; set; }
        [Display(Name = "HomeTypes")]

        public int HomeTypeId { get; set; }

        public IEnumerable<SelectListItem> HomeProperties { get; set; }
        [Display(Name = "HomeProperties")]
        [Required]
        public IEnumerable<int> HomePropertyIds { get; set; }

    }
}
