using System;

namespace Escola.Alf.Application.Model
{
    public abstract class AlunoModelBase
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
