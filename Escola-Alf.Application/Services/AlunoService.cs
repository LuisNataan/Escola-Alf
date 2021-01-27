using Escola.Alf.Application.Interfaces;
using Escola.Alf.Application.Model.Aluno;
using Escola.Alf.Domain.Entities;
using Escola.Alf.Domain.VO;
using System.Threading.Tasks;

namespace Escola.Alf.Application.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoService(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public async Task<int> Create(AlunoRequestModel request)
        {
            var alunoVO = new AlunoVO()
            {
                Nome = request.Nome,
                Email = request.Email,
                DataNascimento = request.DataNascimento
            };
            var aluno = new Aluno(alunoVO);

            await _alunoRepository.Create(aluno);
            await _alunoRepository.SaveChanges();
            return aluno.Id;
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<AlunoResponseModel> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(int id, AlunoRequestModel request)
        {
            throw new System.NotImplementedException();
        }
    }
}
