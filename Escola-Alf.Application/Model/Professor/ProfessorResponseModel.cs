namespace Escola.Alf.Application.Model.Professor
{
    public class ProfessorResponseModel : ProfessorModelBase
    {
        public ProfessorResponseModel(ProfessorModelBase model)
        {
            Nome = model.Nome;
            Email = model.Email;
            Disciplina = model.Disciplina;
        }
    }
}
