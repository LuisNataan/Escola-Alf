using Escola.Alf.Application.Model;

namespace Escola.Alf.Application
{
    public class ProfessorModel : ModelBase
    {
        public string Nome { get; protected set; }
        public string Email { get; protected set; }
        public string Disciplina { get; protected set; }
    }
}
