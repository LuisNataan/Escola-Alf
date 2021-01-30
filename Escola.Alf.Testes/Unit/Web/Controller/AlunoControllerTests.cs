using Escola.Alf.Application.Interfaces;
using Escola.Alf.Application.Model.Aluno;
using Escola.Alf.Solution.Controller;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System.Threading.Tasks;
using Xunit;

namespace Escola.Alf.Testes.Unit.Web.Controller
{
    public class AlunoControllerTests
    {
        private readonly IAlunoService _alunoService;
        private readonly AlunoController _alunoController;

        public AlunoControllerTests()
        {
            _alunoService = NSubstitute.Substitute.For<IAlunoService>();
            _alunoController = new AlunoController(_alunoService);
        }

        [Fact]
        public async Task Create_DeveCriarAluno()
        {
            var alunoRequestModel = new AlunoRequestModel();

            var result = await _alunoController.Create(alunoRequestModel);

            result.Should().NotBeNull();
            result.Should().BeOfType<CreatedAtRouteResult>();

            await _alunoService.Received(1).Create(alunoRequestModel);
        }

        [Fact]
        public async Task Update_DeveAtualizarAluno()
        {
            var id = 1;
            var alunoRequestModel = new AlunoRequestModel();

            var result = await _alunoController.Update(id, alunoRequestModel);

            result.Should().NotBeNull();
            result.Should().BeOfType<OkObjectResult>();
            await _alunoService.Received(1).Update(id, alunoRequestModel);
        }

        [Fact]
        public async Task Delete_DeveDesativarAluno()
        {
            var id = 2;

            var result = await _alunoController.Delete(id);

            result.Should().NotBeNull();
            result.Should().BeOfType<NoContentResult>();
            await _alunoService.Received(1).Delete(id);
        }

        [Fact]
        public async Task GetById_DeveTrazerAluno()
        {
            var id = 3;

            var result = await _alunoController.GetById(id);

            result.Should().NotBeNull();
            result.Should().BeOfType<OkObjectResult>();
            await _alunoService.Received(1).GetById(id);
        }
    }
}
