namespace Escola.Alf.Domain
{
    public abstract class BaseEntity
    {
        public int Id { get; protected set; }
        public bool Deletado { get; set; }
    }
}
