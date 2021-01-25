using Escola.Alf.Domain.Entities;
using System.Threading.Tasks;

namespace Escola.Alf.Application.Interfaces
{
    public interface IProfessorRepository : IGenericRepository<Professor>
    {
        Task<bool> VerificarProfessor(int id);
    }
}
