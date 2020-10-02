namespace TimeOffManager.Application.Identity.Commands.CreateUser
{
    using static Domain.Vacations.Models.ModelConstants.Common;
    
    using FluentValidation;

    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            this.RuleFor(u => u.Email)
                .MinimumLength(MinEmailLength)
                .MaximumLength(MaxEmailLength)
                .EmailAddress()
                .NotEmpty();

            this.RuleFor(u => u.Password)
                .MaximumLength(MaxNameLength)
                .NotEmpty();
        }
    }
}
