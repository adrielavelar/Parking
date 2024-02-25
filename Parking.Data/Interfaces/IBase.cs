namespace Parking.Data.Interfaces
{
    public interface IBase<T>
    {
        Task Add(T entity);
        Task<T> GetById(string id);
        Task Update(T entity);
        Task Delete(string id);
        Task<int> Count();
        Task<IEnumerable<T>> GetAll();
    }
}
