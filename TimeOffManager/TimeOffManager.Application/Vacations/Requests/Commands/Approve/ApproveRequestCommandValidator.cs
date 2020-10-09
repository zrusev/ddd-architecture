namespace TimeOffManager.Application.Vacations.Requests.Commands.Approve
{
    using FluentValidation;
    using static Domain.Vacations.Models.ModelConstants.Common;

    public class ApproveRequestCommandValidator : AbstractValidator<ApproveRequestCommand>
    {
        public ApproveRequestCommandValidator()
        {
            this.RuleFor(u => u.ApproverComment)
                .MaximumLength(MaxDescriptionLength);
        }
    }
}
