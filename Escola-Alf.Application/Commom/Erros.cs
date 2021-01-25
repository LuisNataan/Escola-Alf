namespace Escola.Alf.Application.Commom
{
    public class Erros
    {
        public string Message { get; set; }
        public string FieldName { get; set; }

        public Erros(string message, string fieldName)
        {
            Message = message;
            FieldName = fieldName;
        }

        protected Erros() 
        {
        }
    }
}
