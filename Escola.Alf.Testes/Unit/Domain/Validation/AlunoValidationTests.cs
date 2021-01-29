using Escola.Alf.Domain.Entities;
using Escola.Alf.Domain.Validation;
using Escola.Alf.Domain.VO;
using FluentValidation.TestHelper;
using Xunit;

namespace Escola.Alf.Testes.Unit.Domain.Validation
{
    public class AlunoValidationTests
    {
        private readonly AlunoValidation _validator;

        public AlunoValidationTests()
        {
            _validator = new AlunoValidation();
        }

        [Fact]
        public void DeveLancarExcessao_QuandoNomeForVazio()
        {
            var alunoVO = new AlunoVO()
            {
                Nome = string.Empty
            };
            var aluno = new Aluno(alunoVO);

            _validator.ShouldHaveValidationErrorFor(a => a.Nome, aluno)
                .WithErrorMessage("Nome não pode estar vazio e deve conter de 5 a 60 caracteres.");
        }

        [Fact]
        public void DeveLancarExcessao_QuandoEmailForVazio()
        {
            var alunoVO = new AlunoVO()
            {
                Email = string.Empty
            };
            var aluno = new Aluno(alunoVO);

            _validator.ShouldHaveValidationErrorFor(a => a.Email, aluno)
                .WithErrorMessage("Email não pode estar vazio e deve conter de 12 a 60 caracteres.");
        }

        [Fact]
        public void DeveLancarExcessao_QuandoEmailEstiverIncorreto()
        {
            var alunoVO = new AlunoVO()
            {
                Email = "jaosilva$jmeiu.com"
            };
            var aluno = new Aluno(alunoVO);

            _validator.ShouldHaveValidationErrorFor(a => a.Email, aluno)
                .WithErrorMessage("Email inválido.");
        }
    }
}
