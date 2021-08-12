using FitnessBooking.Core.Interfaces.Repositories;
using FitnessBooking.Data.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessBooking.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        protected readonly FitnessBookingContext RepositoryContext;

        public Repository(FitnessBookingContext RepositoryContext)
        {
            this.RepositoryContext = RepositoryContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return RepositoryContext.Set<TEntity>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {

                await RepositoryContext.AddAsync(entity);
                await RepositoryContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                RepositoryContext.Update(entity);
                await RepositoryContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }
    }
}