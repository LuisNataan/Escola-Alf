using System.Collections.Generic;

namespace Escola.Alf.Domain.ComplexType
{
    public class Prova : BaseEntity
    {
        public List<Prova> Questoes { get; protected set; }
    }
}
