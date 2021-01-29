using Escola.Alf.Domain.VO;

namespace Escola.Alf.Application.Model.Aluno
{
    public class ProvaModel
    {
        public double Nota { get; set; }
        public int AlunoId { get; set; }

        public ProvaModel()
        {

        }

        public ProvaModel(AlunoVO aluno)
        {
            Nota = aluno.Nota;
        }
    }
}
