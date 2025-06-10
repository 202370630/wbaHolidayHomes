namespace EE.HolidayHomes.Core.Entities
{
    public class HolidayHome : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }

        public HomeType HomeType { get; set; }

        public int? HomeTypeId { get; set; }

        public ICollection<HomeProperty> HomeProperties { get; set; }
    }
}
