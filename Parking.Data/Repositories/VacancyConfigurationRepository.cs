using Microsoft.EntityFrameworkCore;
using Parking.Data.Entities;
using Parking.Data.Interfaces;

namespace Parking.Data.Repositories
{
    public class VacancyConfigurationRepository : IVacancyConfiguration
    {
        public VacancyConfigurationRepository()
        {

        }

        public Task Add(VacancyConfiguration entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Count()
        {
            throw new NotImplementedException();
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<VacancyConfiguration>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<VacancyConfiguration> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<VacancyConfiguration> GetConfiguration()
        {
            using var context = new ParkingContext();

            var configuration = await context
                .VacancyConfigurations
                .AsQueryable()
                .SingleOrDefaultAsync();

            return configuration;
        }

        public Task Update(VacancyConfiguration entity)
        {
            throw new NotImplementedException();
        }
    }
}
