using Parking.Data.Entities;

namespace Parking.Data.Interfaces
{
    public interface IVacancyConfiguration : IBase<VacancyConfiguration>
    {
        Task<VacancyConfiguration> GetConfiguration();
    }
}
