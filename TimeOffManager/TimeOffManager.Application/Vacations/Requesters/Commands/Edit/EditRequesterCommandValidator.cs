namespace TimeOffManager.Application.Vacations.Requesters.Commands.Edit
{
    using FluentValidation;
    using static Domain.Vacations.Models.ModelConstants.Common;

    public class EditRequesterCommandValidator : AbstractValidator<EditRequesterCommand>
    {
        public EditRequesterCommandValidator()
        {
            this.RuleFor(u => u.FirstName)
                .MinimumLength(MinNameLength)
                .MaximumLength(MaxNameLength)
                .NotEmpty();

            this.RuleFor(u => u.LastName)
                .MinimumLength(MinNameLength)
                .MaximumLength(MaxNameLength)
                .NotEmpty();

            this.RuleFor(u => u.EmployeeId)
                .MaximumLength(EIDLength)
                .NotEmpty();

            this.RuleFor(u => u.ImageUrl)
                .MaximumLength(MaxUrlLength)
                .NotEmpty();
        }
    }
}
