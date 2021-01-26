using Escola.Alf.Domain.ComplexType;
using Escola.Alf.Domain.VO;
using System.Collections.Generic;

namespace Escola.Alf.Domain.Entities
{
    public class Professor : BaseEntity
    {
        public string Nome { get; protected set; }
        public string Email { get; protected set; }
        public string Disciplina { get; protected set; }
        public virtual Prova Prova { get; protected set; }
        public List<Prova> Provas { get; protected set; }

        public Professor(ProfessorVO professorVO)
        {
            Nome = professorVO.Nome;
            Email = professorVO.Email;
            Disciplina = professorVO.Disciplina;
        }

        protected Professor()
        {
        }

        public void Inativar()
        {
            this.Deletado = true;
        }
    }
}
