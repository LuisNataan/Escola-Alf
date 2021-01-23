namespace Escola.Alf.Application.Model.Professor
{
    public class ProfessorResponseModel : ProfessorModel
    {
        public ProfessorResponseModel(ProfessorModel model)
        {
            Id = model.Id;
            Nome = model.Nome;
            Email = model.Email;
            Disciplina = model.Disciplina;
        }
    }
}
