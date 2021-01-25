namespace Escola.Alf.Domain.Entities
{
    public class Professor : BaseEntity
    {
        public string Nome { get; protected set; }
        public string Email { get; protected set; }
        public string Disciplina { get; protected set; }
    }
}
