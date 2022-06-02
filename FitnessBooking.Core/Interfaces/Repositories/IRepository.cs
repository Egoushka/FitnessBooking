using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FitnessBooking.Core.Models.Dto.Gym;

namespace FitnessBooking.Core.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        IQueryable<TEntity> GetAll();
        TEntity GetEntityById(int id);
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);
    }
}