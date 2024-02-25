using Parking.Domain.Enums;

namespace Parking.Application.Interfaces
{
    public interface IVacancyService
    {
        Task<int> GetEmptyVacancies();
        Task<int> GetTotalVacancies();
        Task<StatusEnum> GetStatus();
        Task<bool> IsVacanciesFull(TypeEnum type);
        Task<int> GetVanBusyVacancies();
    }
}
