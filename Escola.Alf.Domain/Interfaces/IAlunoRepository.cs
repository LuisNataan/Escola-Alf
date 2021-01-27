using Escola.Alf.Domain.Entities;
using System.Threading.Tasks;

namespace Escola.Alf.Application.Interfaces
{
    public interface IAlunoRepository : IGenericRepository<Aluno>
    {
        Task<bool> VerificarAluno(int id);
    }
}
