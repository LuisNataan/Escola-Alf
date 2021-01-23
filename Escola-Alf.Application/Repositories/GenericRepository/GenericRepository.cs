using Escola.Alf.Application.Interfaces;
using Escola.Alf.Application.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Escola.Alf.Application.Repositories.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : ModelBase
    {
        protected readonly MainContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public GenericRepository(MainContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public Task<TEntity> Create(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<TEntity> Delete(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<TEntity> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public Task<TEntity> Update(TEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
