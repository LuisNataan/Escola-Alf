using Escola.Alf.Application.Interfaces;
using Escola.Alf.Application.Model.Professor;
using Escola.Alf.Domain.Entities;
using Escola.Alf.Domain.VO;
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

        public async Task<int> Create(ProfessorRequestModel request)
        {
            var professorVO = new ProfessorVO()
            {
                Nome = request.Nome,
                Email = request.Email,
                Disciplina = request.Disciplina
            };
            var professor = new Professor(professorVO);

            await _professorRepository.Create(professor);
            await _professorRepository.SaveChanges();
            return professor.Id;
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
