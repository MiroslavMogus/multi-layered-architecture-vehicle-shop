using System;
using System.Threading.Tasks;

namespace VehicleShopApp.Repository.Common
{
    public interface IUnitOfWork : IDisposable
    {
        int CommitAsync();

        Task<int> AddAsync<T>(T entity) where T : class;
        Task<int> UpdateAsync<T>(T entity) where T : class;
        Task<int> DeleteAsync<T>(T entity) where T : class;
        Task<int> DeleteAsync<T>(Guid id) where T : class;
    }
}