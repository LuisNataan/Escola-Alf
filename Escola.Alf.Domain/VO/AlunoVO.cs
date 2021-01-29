using System;

namespace Escola.Alf.Domain.VO
{
    public class AlunoVO
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string DataNascimento { get; set; }
        public double Nota { get; set; }
        public int ProvaId { get; set; }
    }
}
