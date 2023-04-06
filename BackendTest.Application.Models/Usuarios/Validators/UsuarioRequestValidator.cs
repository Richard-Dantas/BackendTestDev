using FluentValidation;

namespace BackendTest.Application.Models.Usuarios.Validators
{
    public class UsuarioRequestValidator : AbstractValidator<UsuarioRequest>
    {
        public UsuarioRequestValidator()
        {
            RuleFor(dto => dto.Email)
                .NotEmpty();

            RuleFor(dto => dto.Name)
                .NotEmpty();
        }
    }
}
