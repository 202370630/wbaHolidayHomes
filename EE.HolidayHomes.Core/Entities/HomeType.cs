using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EE.HolidayHomes.Core.Entities
{
    public class HomeType : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<HolidayHome> HolidayHomes { get; set; }
    }
}
