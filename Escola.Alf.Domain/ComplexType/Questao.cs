namespace Escola.Alf.Domain.ComplexType
{
    public class Questao : BaseEntity
    {
        public string Pergunta { get; protected set; }
        public string Resposta { get; protected set; }
        public int Numero { get; protected set; }
        public bool Correta { get; protected set; }
        public int Peso { get; protected set; }

        public Questao(string pergunta, string resposta, int numero, bool correta, int peso)
        {
            Pergunta = pergunta;
            Resposta = resposta;
            Numero = numero;
            Correta = correta;
            Peso = peso;
        }

        protected Questao()
        {
        }
    }
}
