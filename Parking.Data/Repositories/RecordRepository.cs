using Microsoft.EntityFrameworkCore;
using Parking.Data.Entities;
using Parking.Data.Interfaces;
using Parking.Domain.Enums;

namespace Parking.Data.Repositories
{
    public class RecordRepository : IRecordRepository
    {
        public RecordRepository()
        {

        }

        public Task Add(Record entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Count()
        {
            using var context = new ParkingContext();

            var total = await context
                .Records
                .AsQueryable()
                .CountAsync();

            return total;
        }

        public async Task<int> CountBusyVacancies()
        {
            using var context = new ParkingContext();

            var total = await context
                .Records
                .Where(x => x.Out == null && x.Active)
                .AsQueryable()
                .CountAsync();

            return total;
        }

        public async Task<int> CountByVacancyType(TypeEnum type)
        {
            using var context = new ParkingContext();

            var total = await context
                .Records
                .AsQueryable()
                .CountAsync(x => x.Type == type);

            return total;
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Record>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Record>> GetAllBusyVacancies()
        {
            using var context = new ParkingContext();

            var records = await context
                .Records
                .Where(x => x.Out == null && x.Active)
                .ToListAsync();

            return records;
        }

        public Task<Record> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Record entity)
        {
            throw new NotImplementedException();
        }
    }
}
