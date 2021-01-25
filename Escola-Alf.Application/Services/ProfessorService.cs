using Escola.Alf.Application.Interfaces;
using Escola.Alf.Application.Model.Professor;
using System.Threading.Tasks;

namespace Escola.Alf.Application.Services
{
    public class ProfessorService : IProfessorService
    {
        private readonly IProfessorRepository _professorRepository;

        public ProfessorService(IProfessorRepository professorRepository)
        {
            _professorRepository = professorRepository;
        }

        public Task<int> Create(ProfessorRequestModel request)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ProfessorResponseModel> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(int id, ProfessorRequestModel request)
        {
            throw new System.NotImplementedException();
        }
    }
}
