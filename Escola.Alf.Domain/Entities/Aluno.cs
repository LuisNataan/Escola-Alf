using Escola.Alf.Domain.ComplexType;
using Escola.Alf.Domain.VO;
using System;
using System.Collections.Generic;

namespace Escola.Alf.Domain.Entities
{
    public class Aluno : BaseEntity
    {
        public string Nome { get; protected set; }
        public string Email { get; protected set; }
        public DateTime DataNascimento { get; protected set; }
        public virtual Prova Prova { get; protected set; }
        public List<Prova> Provas { get; protected set; }

        public Aluno(AlunoVO professorVO)
        {
            Nome = professorVO.Nome;
            Email = professorVO.Email;
        }

        protected Aluno()
        {
        }

        public void Inativar()
        {
            this.Deletado = true;
        }
    }
}
