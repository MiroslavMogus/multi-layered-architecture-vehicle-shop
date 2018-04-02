using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Threading.Tasks;
using System.Transactions;
using VehicleShopApp.DAL;
using VehicleShopApp.Model;
using VehicleShopApp.Resources;

namespace VehicleShopApp.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        protected VehicleShopDbContext context { get; set; }

        public UnitOfWork(VehicleShopDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// CommitAsync method.
        /// Because of limitations of System.Transactions in EF Core I did not use it.
        /// EF Core relies on database providers to implement support for System.Transactions.
        /// Although support is quite common among ADO.NET providers for .NET Framework, the API has only been recently added to .NET Core and hence support is not be as widespread.
        /// If a provider does not implement support for System.Transactions, it is possible that calls to these APIs will be completely ignored. 
        /// SqlClient for .NET Core does support it from 2.1 onwards.SqlClient for .NET Core 2.0 will throw an exception of you attempt to use the feature.
        /// </summary>
        public  int CommitAsync()
        {
            int result = 0;

            result = context.SaveChanges();

            return result;
        }

        public virtual Task<int> AddAsync<T>(T entity) where T : class
        {
            try
            {
                
                EntityEntry dbEntityEntry = context.Entry(entity);
                if (dbEntityEntry.State != EntityState.Detached)
                {
                    dbEntityEntry.State = EntityState.Added;
                }
                else
                {
                    context.Set<T>().Add(entity);
                    
                }
                
                return Task.FromResult(1);
                
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public Task<int> UpdateAsync<T>(T entity) where T : class
        {
            try
            {
                EntityEntry dbEntityEntry = context.Entry(entity);
                if (dbEntityEntry.State == EntityState.Detached)
                {
                    context.Set<T>().Attach(entity);
                }
                dbEntityEntry.State = EntityState.Modified;
                return Task.FromResult(1);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Task<int> DeleteAsync<T>(T entity) where T : class
        {
            try
            {
                EntityEntry dbEntityEntry = context.Entry(entity);
                if (dbEntityEntry.State != EntityState.Deleted)
                {
                    dbEntityEntry.State = EntityState.Deleted;
                }
                else
                {
                    context.Set<T>().Attach(entity);
                    context.Set<T>().Remove(entity);
                }
                return Task.FromResult(1);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual Task<int> DeleteAsync<T>(Guid id) where T : class
        {
            var entity = context.Set<T>().Find(id);
            if (entity == null)
            {
                return null;
            }
            return DeleteAsync<T>(entity);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~UnitOfWork() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

    }

}