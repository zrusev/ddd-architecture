namespace TimeOffManager.Application.Vacations.Requests.Commands.Create
{
    using FluentValidation;
    using static Domain.Vacations.Models.ModelConstants.Request;

    public class CreateRequestCommandValidator : AbstractValidator<CreateRequestCommand>
    {
        public CreateRequestCommandValidator()
        {
            this.RuleFor(u => u.RequesterComment)
                .MaximumLength(MaxCommentLength);

            this.RuleFor(u => u.Start)
                .NotEmpty();

            this.RuleFor(u => u.End)
                .NotEmpty();

            this.RuleFor(d => d.End)
                .GreaterThanOrEqualTo(e => e.Start);

            this.RuleFor(u => u.Hours)
                .NotEmpty();

            this.RuleFor(u => u.RequestTypeName)
                .NotEmpty();
        }
    }
}
