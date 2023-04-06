using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendTest.Application.Models.Tarefas.Validators
{
    public class TarefaRequestValidator : AbstractValidator<TarefaRequest>
    {
        public TarefaRequestValidator()
        {
            RuleFor(dto => dto.Descricao)
                .NotEmpty();

            RuleFor(dto => dto.Status)
                .NotEmpty()
                .IsInEnum();

            RuleFor(dto => dto.DataInicio)
                .NotEmpty();

        }
    }
}
