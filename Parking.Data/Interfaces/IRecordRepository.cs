using Parking.Data.Entities;
using Parking.Domain.Enums;

namespace Parking.Data.Interfaces
{
    public interface IRecordRepository : IBase<Record>
    {
        Task<int> CountBusyVacancies();
        Task<int> CountByVacancyType(TypeEnum type);
        Task<IEnumerable<Record>> GetAllBusyVacancies();
    }
}
