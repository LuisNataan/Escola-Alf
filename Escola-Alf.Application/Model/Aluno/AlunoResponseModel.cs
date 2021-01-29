namespace Escola.Alf.Application.Model.Aluno
{
    public class AlunoResponseModel : AlunoModelBase
    {
        public int Id { get; set; }

        public AlunoResponseModel(Domain.Entities.Aluno aluno)
        {
            Id = aluno.Id;
            Nome = aluno.Nome;
            Email = aluno.Email;
            DataNascimento = aluno.DataNascimento;
            Aprovado = aluno.Aprovado;
            Prova = new ProvaModel
            {
                Nota = aluno.Prova.Nota
            };
        }
    }
}
