using Escola.Alf.Domain.VO;
using System.Collections.Generic;

namespace Escola.Alf.Domain.ComplexType
{
    public class Prova : BaseEntity
    {
        public List<Questao> Questoes { get; protected set; }
        public double Nota { get; protected set; }
        public int AlunoId { get; protected set; }

        public Prova(AlunoVO alunoVO)
        {
            Nota = alunoVO.Nota;
        }

        protected Prova()
        {

        }

        public void GetNota()
        {
            int totalPeso = 0;
            int pontuacaoTotal = 0;

            Questoes.FindAll(x => x.Correta).ForEach(x => pontuacaoTotal += x.Peso);
            Questoes.ForEach(x => totalPeso += x.Peso);

            Nota = pontuacaoTotal / totalPeso;
        }
        
        //TODO: Método para aplicar a prova.
    }
}
