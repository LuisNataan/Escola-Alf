using Escola.Alf.Application.Model.Professor;
using System.Threading.Tasks;

namespace Escola.Alf.Application.Interfaces
{
    public interface IProfessorService
    {
        Task<int> Create(ProfessorRequestModel request);
        Task Update(int id, ProfessorRequestModel request);
        Task Delete(int id);
        Task<ProfessorResponseModel> GetById(int id);
    }
}
