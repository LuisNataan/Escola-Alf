﻿using Escola.Alf.Domain.Entities;
using FluentValidation;
using System;

namespace Escola.Alf.Domain.Validation
{
    public class AlunoValidation : AbstractValidator<Aluno>
    {
        private string _stringRule = "^[a - zA - ZáàâãéèêíïóôõöúçñÁÀÂÃÉÈÊÍÏÓÔÕÖÚÇÑ] + $";

        public AlunoValidation()
        {
            RuleFor(a => a.Nome)
                .Length(5, 60).WithMessage("Nome não pode estar vazio e deve vonter de 5 a 60 caracteres.")
                .Matches(_stringRule).WithMessage("Nome contém caracteres inválidos.");

            RuleFor(a => a.Email)
                .Length(12, 60).WithMessage("Email não pode estar vazio e deve conter de 12 a 60 caracteres.")
                .EmailAddress().WithMessage("Email inválido.");

            RuleFor(a => a.DataNascimento)
                .NotEmpty().WithMessage("Data de Nascimento não pode estar vazia.")
                .LessThan(DateTime.Now).WithMessage("Insira uma data de nascimento válida.");
        }

    }
}
