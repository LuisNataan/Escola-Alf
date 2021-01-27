using Escola.Alf.Application.Model.Aluno;
using System.Threading.Tasks;

namespace Escola.Alf.Application.Interfaces
{
    public interface IAlunoService
    {
        Task<int> Create(AlunoRequestModel request);
        Task Update(int id, AlunoRequestModel request);
        Task Delete(int id);
        Task<AlunoResponseModel> GetById(int id);
    }
}
