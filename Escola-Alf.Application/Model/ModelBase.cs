namespace Escola.Alf.Application.Model
{
    public abstract class ModelBase
    {
        public int Id { get; protected set; }
        public bool Deletado { get; protected set; }
    }
}
