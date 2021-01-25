using System;
using System.Collections.Generic;

namespace Escola.Alf.Application.Commom
{
    public class ValidateException : Exception
    {
        public List<Erros> Erros { get; protected set; }

        public ValidateException(List<Erros> erros)
        {
            Erros = erros;
        }

        public ValidateException(string message) : base(message) { }
        public ValidateException(string message, Exception inner) : base(message, inner) { }
        protected ValidateException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : (info, context) { }
    }
}
