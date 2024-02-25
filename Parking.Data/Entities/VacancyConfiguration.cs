namespace Parking.Data.Entities
{
    public class VacancyConfiguration
    {
        public Guid Id { get; set; }
        public int MotorcycleVacancies { get; set; }
        public int LargeVacancies { get; set; }
        public int NormalVacancies { get; set; }
        public int TotalVacancies { get; set; }
    }
}
