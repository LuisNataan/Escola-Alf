using Escola.Alf.Domain.Entities;
using Escola.Alf.Domain.VO;
using FluentAssertions;
using System;
using Xunit;

namespace Escola.Alf.Testes.Unit.Domain.Entities
{
    public class AlunoEntityTest
    {
        [Fact]
        public void ValidarAluno()
        {
            var alunoVO = new AlunoVO()
            {
                Nome = "Gabriel da Silva",
                Email = "gabsilva@hotmail.com",
                DataNascimento = "12/03/2000",
            };

            var aluno = new Aluno(alunoVO);
            var exception = Record.Exception(() => aluno.Validar());

            exception.Should().BeNull();
        }
        [Fact]
        public void Erro_ValidarAluno()
        {
            var alunoVO = new AlunoVO()
            {
                Nome = "G@briel d@ Silva",
                Email = "gabsilva@gmail.com",
                DataNascimento = "12/03/2000"
            };

            var aluno = new Aluno(alunoVO);
            try
            {
                aluno.Validar();
            }
            catch (Exception ex)
            {
                ex.Message.Should().Be("Validation failed: \r\n -- Nome: Nome contém caracteres inválidos.");
            }
        }

        [Fact]
        public void InativarAluno()
        {
            var alunoVO = new AlunoVO()
            {
                Nome = "Jo#o d@ Silva",
                Email = "jaosilva.com",
                DataNascimento = "12/03/2000"
            };
            var aluno = new Aluno(alunoVO);
            aluno.Inativar();

            aluno.Deletado.Should().BeTrue();
        }

        [Fact]
        public void AtualizarAluno()
        {
            var alunoVO = new AlunoVO()
            {
                Nome = "João da Silva",
                Email = "jaosilva.com",
                DataNascimento = "12/03/2000"
            };
            var aluno = new Aluno(alunoVO);

            var alunoRequestModel = new AlunoVO
            {
                Nome = "João da Silva",
                Email = "joaozinho@gmail.com",
                DataNascimento = "12/03/2000"
            };

            aluno.Atualizar(alunoRequestModel);

            aluno.Should().Equals(alunoRequestModel);
        }
    }
}
