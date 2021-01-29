using Escola.Alf.Application.Interfaces;
using Escola.Alf.Application.Model.Aluno;
using Escola.Alf.Application.Services;
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
                DataNascimento = "02/10/2001",
            };

        }
    }
}
