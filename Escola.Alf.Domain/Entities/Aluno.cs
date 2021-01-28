using Escola.Alf.Domain.ComplexType;
using Escola.Alf.Domain.Validation;
using Escola.Alf.Domain.VO;
using FluentValidation;
using System;

namespace Escola.Alf.Domain.Entities
{
    public class Aluno : BaseEntity
    {
        public string Nome { get; protected set; }
        public string Email { get; protected set; }
        public DateTime DataNascimento { get; protected set; }
        public virtual Prova Prova { get; protected set; }
        public int ProvaId { get; protected set; }
        public bool Aprovado { get; protected set; }

        public Aluno(AlunoVO alunoVO)
        {
            Nome = alunoVO.Nome;
            Email = alunoVO.Email;
            DataNascimento = alunoVO.DataNascimento;
            ProvaId = alunoVO.ProvaId;
        }

        protected Aluno()
        {
        }

        public void Atualizar(AlunoVO aluno)
        {
            Nome = aluno.Nome;
            Email = aluno.Email;
            DataNascimento = aluno.DataNascimento;
        }

        public void Validar()
        {
            var alunoValidator = new AlunoValidation();
            alunoValidator.ValidateAndThrow(this);
        }

        public void Inativar()
        {
            this.Deletado = true;
        }
    }
}
