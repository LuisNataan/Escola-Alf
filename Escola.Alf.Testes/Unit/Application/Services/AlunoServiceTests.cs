using Escola.Alf.Application.Interfaces;
using Escola.Alf.Application.Model.Aluno;
using Escola.Alf.Application.Services;
using Escola.Alf.Domain.Entities;
using Escola.Alf.Domain.VO;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Escola.Alf.Testes.Unit.Application.Services
{
    public class AlunoServiceTests
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly AlunoService _alunoService;

        public AlunoServiceTests()
        {
            _alunoRepository = NSubstitute.Substitute.For<IAlunoRepository>();
            _alunoService = new AlunoService(_alunoRepository);
        }

        [Fact]
        public async Task Create_DeveCriarAluno()
        {
            var alunoRequestModel = new AlunoRequestModel()
            {
                Nome = "João da Silva",
                Email = "jaozinho@gmail.com",
                DataNascimento = "02/10/2001"
            };

            var alunoSalvo = new List<Aluno>();
            _alunoRepository.When(a => a.Create(Arg.Any<Aluno>())).Do(a => alunoSalvo.Add((Aluno)a.Args()[0]));
            await _alunoService.Create(alunoRequestModel);

            alunoSalvo.Should().NotBeEmpty();
        }

        [Fact]
        public async Task Create_DeveLancarExcessao_VerificarAluno()
        {
            var alunoRequestModel = new AlunoRequestModel()
            {
                Nome = "João da Silva",
                Email = "jaozinho@gmail.com",
                DataNascimento = "02/10/2001"
            };
            var alunoSalvo = new List<Aluno>();
            _alunoRepository.VerificarAluno(Arg.Any<int>()).Returns(true);

            var exceptions = await Record.ExceptionAsync(() => _alunoService.Create(alunoRequestModel));

            exceptions.Should().BeOfType<ArgumentException>();
            exceptions.Message.Should().Be("Aluno já cadastrado.");
        }

        [Fact]
        public async Task Delete_DeveDesativarAluno()
        {
            var alunoVO = new AlunoVO()
            {
                Nome = "João da Silva",
                Email = "jaozinho@gmail.com",
                DataNascimento = "02/10/2001"
            };
            var aluno = new Aluno(alunoVO);

            _alunoRepository.GetById(100).Returns(aluno);

            await _alunoService.Delete(100);
            await _alunoRepository.Received(1).Delete(Arg.Is(aluno));

            aluno.Deletado.Should().BeTrue();
        }

        [Fact]
        public async Task Delete_DeveLancarExcessao_IdInvalido()
        {
            var alunoVO = new AlunoVO()
            {
                Nome = "João da Silva",
                Email = "jaozinho@gmail.com",
                DataNascimento = "02/10/2001"
            };
            var aluno = new Aluno(alunoVO);

            _alunoRepository.GetById(10).Returns(aluno);

            var exception = await Record.ExceptionAsync(() => _alunoService.Delete(aluno.Id));

            exception.Should().BeOfType<ArgumentException>();
            exception.Message.Should().Be("Id inválido.");
        }

        [Fact]
        public async Task GetById_DeveTrazerAluno()
        {
            var alunoVO = new AlunoVO()
            {
                Nome = "João da Silva",
                Email = "jaozinho@gmail.com",
                DataNascimento = "02/10/2001"
            };
            var aluno = new Aluno(alunoVO);

            _alunoRepository.GetById(aluno.Id).Returns(aluno);

            var alunoRequestModel = await _alunoService.GetById(aluno.Id);
            alunoRequestModel.Should().NotBeNull();
        }

        [Fact]
        public async Task GetById_DeveLancerExcessao_IdInvalido()
        {
            var alunoVO = new AlunoVO()
            {
                Nome = "João da Silva",
                Email = "jaozinho@gmail.com",
                DataNascimento = "02/10/2001"
            };
            var aluno = new Aluno(alunoVO);

            _alunoRepository.GetById(30).Returns(aluno);

            var exception = await Record.ExceptionAsync(() => _alunoService.GetById(aluno.Id));

            exception.Should().BeOfType<ArgumentException>();
            exception.Message.Should().Be("Id inválido.");
        }

        [Fact]
        public async Task Update_DeveAtualizarAluno()
        {
            var alunoVO = new AlunoVO()
            {
                Nome = "João da Silva",
                Email = "jaozinho@gmail.com",
                DataNascimento = "02/10/2001",
                Nota = 8
            };
            var aluno = new Aluno(alunoVO);

            var alunoRequestModel = new AlunoRequestModel()
            {
                Nome = "João da Silva",
                Email = "joaodasilva@outlook.com",
                DataNascimento = "02/10/2001"
            };

            _alunoRepository.GetById(aluno.Id).Returns(aluno);

            await _alunoService.Update(aluno.Id, alunoRequestModel);

            aluno.Should().Equals(alunoRequestModel);
        }

        [Fact]
        public async Task Update_DeveLancarExcessao_IdInvalido()
        {
            var alunoVO = new AlunoVO()
            {
                Nome = "João da Silva",
                Email = "jaozinho@gmail.com",
                DataNascimento = "02/10/2001",
                Nota = 8
            };
            var aluno = new Aluno(alunoVO);

            var alunoRequestModel = new AlunoRequestModel()
            {
                Nome = "João da Silva",
                Email = "joaodasilva@outlook.com",
                DataNascimento = "02/10/2001"
            };

            _alunoRepository.GetById(1).Returns(aluno);

            var exception = await Record.ExceptionAsync(() => _alunoService.Update(aluno.Id, alunoRequestModel));

            exception.Should().BeOfType<ArgumentException>();
            exception.Message.Should().Be("Id inválido.");
        }
    }
}
