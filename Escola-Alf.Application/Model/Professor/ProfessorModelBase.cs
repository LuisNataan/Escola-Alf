using Escola.Alf.Application.Model;

namespace Escola.Alf.Application
{
    public class ProfessorModelBase
    {
        public string Nome { get; protected set; }
        public string Email { get; protected set; }
        public string Disciplina { get; protected set; }

        public ProfessorModelBase(ProfessorModelBase professor)
        {
            Nome = professor.Nome;
            Email = professor.Email;
            Disciplina = professor.Disciplina;
        }
        protected ProfessorModelBase()
        {
        }
    }
}
