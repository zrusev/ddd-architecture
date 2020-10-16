namespace TimeOffManager.Application.Vacations.Requests.Commands.Create
{
    using Common.Contracts;
    using Domain.Vacations.Factories.Requests;
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using TimeOffManager.Application.Common;
    using TimeOffManager.Application.Common.Entities;
    using TimeOffManager.Domain.Vacations.Exceptions;
    using TimeOffManager.Domain.Vacations.Repositories;
    using Vacations.Requesters;
    using Vacations.Requests.Queries;

    public class CreateRequestCommand : IRequest<Result<CreateRequestOutputModel>> 
    {
        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public string RequestTypeName { get; set; } = default!;

        public TimeSpan Hours { get; set; }

        public string? RequesterComment { get; set; }

        public bool IsPlanning { get; set; }

        public bool ExcludeHolidays { get; set; }

        public bool ExcludeWeekends { get; set; }

        public class CreateRequestCommandHandler : IRequestHandler<CreateRequestCommand, Result<CreateRequestOutputModel>>
        {
            private readonly ICurrentUser currentUser;
            private readonly IRequestFactory requestFactory;
            private readonly IRequesterQueryRepository requesterQueryRepository;
            private readonly IRequestQueryRepository requestQueryRepository;
            private readonly IRequestDomainRepository requestDomainRepository;
            private readonly IMailer mailer;

            public CreateRequestCommandHandler(
                ICurrentUser currentUser,
                IRequestFactory requestFactory,
                IRequesterQueryRepository requesterQueryRepository,
                IRequestQueryRepository requestQueryRepository,
                IRequestDomainRepository requestDomainRepository,
                IMailer mailer
                )
            {
                this.currentUser = currentUser;
                this.requestFactory = requestFactory;
                this.requesterQueryRepository = requesterQueryRepository;
                this.requestQueryRepository = requestQueryRepository;
                this.requestDomainRepository = requestDomainRepository;
                this.mailer = mailer;
            }

            public async Task<Result<CreateRequestOutputModel>> Handle(
                CreateRequestCommand request, 
                CancellationToken cancellationToken
                )
            {
                var requester = await this.requesterQueryRepository.FindByUser(
                    this.currentUser.UserId,
                    cancellationToken);

                var manager = requester.Employee.Manager 
                    ?? throw new InvalidManagerException(InvalidManagerException.NonExistingManger);

                var pTOBalance = requester.Employee.PTOBalance
                    ?? throw new InvalidPTOBalanceException(InvalidPTOBalanceException.NonExistingPTOBalance);

                var requestType = await this.requestQueryRepository.GetRequestType(
                    request.RequestTypeName,
                    cancellationToken);

                var holidays = await this.requestQueryRepository.GetNationalHolidays(
                    cancellationToken);

                var vacationRequest = this.requestFactory
                    .WithPeriod(request.Start, request.End)
                    .WithDays(request.Start, request.End)
                    .WithApprover(manager.Id)
                    .WithRequesterComment(request.RequesterComment)
                    .WithRequestDates(
                        requestType,
                        request.Hours,
                        request.ExcludeHolidays,
                        request.ExcludeWeekends,
                        holidays)
                    .WithOptions(
                        false, 
                        request.IsPlanning, 
                        request.ExcludeHolidays, 
                        request.ExcludeWeekends)
                    .Build();

                requester.AddRequest(vacationRequest);

                await this.requestDomainRepository.Save(vacationRequest, cancellationToken);

                await mailer.SendEmailAsync(
                    new MailOutputModel(
                        requester.Employee.Manager.FirstName + " " + requester.Employee.Manager.LastName,
                        requester.Employee.Manager.Email,
                        MailOutputModel.CreateCommandRequestSubject,
                        MailOutputModel.CreateCommandRequestBody));

                return new CreateRequestOutputModel(vacationRequest.Id);
            }
        }
    }
}