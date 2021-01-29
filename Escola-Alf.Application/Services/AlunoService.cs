using Escola.Alf.Application.Interfaces;
using Escola.Alf.Application.Model.Aluno;
using Escola.Alf.Domain.Entities;
using Escola.Alf.Domain.VO;
using System;
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

            aluno.Validar();

            bool alunoVerficado = await _alunoRepository.VerificarAluno(aluno.Id);
            if (alunoVerficado)
            {
                throw new ArgumentException("Aluno já cadastrado.");
            }

            await _alunoRepository.Create(aluno);
            await _alunoRepository.SaveChanges();
            return aluno.Id;
        }

        public async Task Delete(int id)
        {
            var aluno = await _alunoRepository.GetById(id);
            if (aluno == null)
            {
                throw new ArgumentException("Id inválido.");
            }

            aluno.Inativar();
            await _alunoRepository.Delete(aluno);
            await _alunoRepository.SaveChanges();
        }

        public async Task<AlunoResponseModel> GetById(int id)
        {
            var aluno = await _alunoRepository.GetById(id);
            if (aluno == null)
            {
                throw new ArgumentException("Id inválido.");
            }

            return new AlunoResponseModel(aluno);
        }

        public async Task Update(int id, AlunoRequestModel request)
        {
            var aluno = await _alunoRepository.GetById(id);

            if (aluno == null)
            {
                throw new ArgumentException("Id inválido.");
            }

            var alunoRequest = new AlunoVO
            {
                Nome = request.Nome,
                Email = request.Email,
                DataNascimento = request.DataNascimento,
                Nota = request.Prova.Nota
            };

            aluno.Atualizar(alunoRequest);
            aluno.Validar();

            await _alunoRepository.Update(aluno);
            await _alunoRepository.SaveChanges();
        }
    }
}
