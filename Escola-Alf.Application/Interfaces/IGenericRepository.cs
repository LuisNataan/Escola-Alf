using Escola.Alf.Application.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Escola.Alf.Application.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : ModelBase
    {
        Task Create(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task SaveChanges();
    }
}
