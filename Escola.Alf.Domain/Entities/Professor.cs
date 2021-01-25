using Escola.Alf.Domain.ComplexType;
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

        protected Professor()
        {
        }

        public void Inativar()
        {
            this.Deletado = true;
        }
    }
}
