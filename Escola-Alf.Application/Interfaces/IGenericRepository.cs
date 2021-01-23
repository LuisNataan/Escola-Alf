using Escola.Alf.Application.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Escola.Alf.Application.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : ModelBase
    {
        Task<TEntity> Create(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> Delete(TEntity entity);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task SaveChanges();
    }
}
