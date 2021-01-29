using Escola.Alf.Application.Model.Aluno;
using System;

namespace Escola.Alf.Application.Model
{
    public abstract class AlunoModelBase
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string DataNascimento { get; set; }
        public bool Aprovado { get; set; }
        public ProvaModel Prova { get; set; }
    }
}
