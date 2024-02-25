using Parking.Application.Interfaces;
using Parking.Data.Entities;
using Parking.Data.Interfaces;
using Parking.Domain.Enums;

namespace Parking.Application.Services
{
    public class VacancyService : IVacancyService
    {
        private readonly IRecordRepository _recordRepository;
        private readonly IVacancyConfiguration _vacancyConfiguration;

        public VacancyService
        (
            IRecordRepository recordRepository,
            IVacancyConfiguration vacancyConfiguration
        )
        {
            _recordRepository = recordRepository;
            _vacancyConfiguration = vacancyConfiguration;
        }

        public async Task<int> GetEmptyVacancies()
        {
            var configuration = await _vacancyConfiguration.GetConfiguration();
            var total = configuration.TotalVacancies;
            var busy = await _recordRepository.CountBusyVacancies();

            return total - busy;
        }

        public async Task<StatusEnum> GetStatus()
        {
            var configuration = await _vacancyConfiguration.GetConfiguration();
            var total = configuration.TotalVacancies;
            var busy = await _recordRepository.CountBusyVacancies();

            if (busy >= total)
            {
                return StatusEnum.Full;
            }

            if (busy == 0)
            {
                return StatusEnum.Empty;
            }

            return StatusEnum.Full;
        }

        public async Task<int> GetTotalVacancies()
        {
            var configuration = await _vacancyConfiguration.GetConfiguration();

            return configuration.TotalVacancies;
        }

        public async Task<bool> IsVacanciesFull(TypeEnum type)
        {
            var total = await GetTotalByType(type);

            var busy = await _recordRepository.CountByVacancyType(type);

            if (busy >= total)
            {
                return true;
            }

            return false;
        }

        public async Task<int> GetVanBusyVacancies()
        {
            var busyVacancies = await _recordRepository.GetAllBusyVacancies();

            var result = busyVacancies
                .Where(x => x.Type == TypeEnum.Large)
                .Sum(x => x.Quantity);

            return result;
        }

        private async Task<int> GetTotalByType(TypeEnum type)
        {
            var configuration = await _vacancyConfiguration.GetConfiguration();

            return type switch
            {
                TypeEnum.Motorcycle => configuration.MotorcycleVacancies,
                TypeEnum.Large => configuration.LargeVacancies,
                TypeEnum.Normal => configuration.NormalVacancies,
                _ => throw new NotImplementedException(),
            };
        }
    }
}
