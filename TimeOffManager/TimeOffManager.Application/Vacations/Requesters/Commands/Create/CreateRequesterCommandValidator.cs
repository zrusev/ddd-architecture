﻿namespace TimeOffManager.Application.Vacations.Requesters.Commands.Create
{
    using FluentValidation;
    using static Domain.Vacations.Models.ModelConstants.Common;

    public class CreateRequesterCommandValidator : AbstractValidator<CreateRequesterCommand>
    {
        public CreateRequesterCommandValidator()
        {
            this.RuleFor(n => n.FirstName)
                .MinimumLength(MinNameLength)
                .MaximumLength(MaxNameLength)
                .NotEmpty();

            this.RuleFor(n => n.LastName)
                .MinimumLength(MinNameLength)
                .MaximumLength(MaxNameLength)
                .NotEmpty();

            this.RuleFor(n => n.EmployeeId)
                .Length(EIDLength)
                .NotEmpty();

            this.RuleFor(n => n.ImageUrl)
                .MaximumLength(MaxUrlLength)
                .NotEmpty();
        }
    }
}
