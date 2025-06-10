namespace EE.HolidayHomes.Core.Entities
{
    public class Location : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<HolidayHome> HolidayHomes { get; set; }
    }
}
