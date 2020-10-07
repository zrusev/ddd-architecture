namespace TimeOffManager.Application.Vacations.Requests.Commands.Create
{
    using Common.Contracts;
    using Domain.Vacations.Factories.Requests;
    using MediatR;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using TimeOffManager.Domain.Vacations.Repositories;
    using Vacations.Requesters;
    using Vacations.Requests.Queries;

    public class CreateRequestCommand : IRequest<CreateRequestOutputModel> 
    {
        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public string RequestTypeName { get; set; } = default!;

        public TimeSpan Hours { get; set; }

        public string? RequesterComment { get; set; }

        public bool IsPlanning { get; set; }

        public bool ExcludeHolidays { get; set; }

        public bool ExcludeWeekends { get; set; }

        public class CreateRequestCommandHandler : IRequestHandler<CreateRequestCommand, CreateRequestOutputModel>
        {
            private readonly ICurrentUser currentUser;
            private readonly IRequestFactory requestFactory;
            private readonly IRequesterQueryRepository requesterQueryRepository;
            private readonly IRequestQueryRepository requestQueryRepository;
            private readonly IRequestDomainRepository requestDomainRepository;

            public CreateRequestCommandHandler(
                ICurrentUser currentUser,
                IRequestFactory requestFactory,
                IRequesterQueryRepository requesterQueryRepository,
                IRequestQueryRepository requestQueryRepository,
                IRequestDomainRepository requestDomainRepository
                )
            {
                this.currentUser = currentUser;
                this.requestFactory = requestFactory;
                this.requesterQueryRepository = requesterQueryRepository;
                this.requestQueryRepository = requestQueryRepository;
                this.requestDomainRepository = requestDomainRepository;
            }

            public async Task<CreateRequestOutputModel> Handle(
                CreateRequestCommand request, 
                CancellationToken cancellationToken
                )
            {
                var requester = await this.requesterQueryRepository.FindByUser(
                    this.currentUser.UserId,
                    cancellationToken);

                var approverId = requester!.Employee!.Manager!.Id;
                
                var pTOBalance = requester.Employee.PTOBalance!;

                var type = await this.requestQueryRepository.GetRequestType(
                    request.RequestTypeName,
                    cancellationToken);

                var holidays = await this.requestQueryRepository.GetNationalHolidays(
                    cancellationToken);

                var userRequests = await this.requesterQueryRepository.GetDetailsWithRequests(
                    requester.Id,
                    cancellationToken);

                var requestedDates = userRequests
                    .Requests
                    .SelectMany(d => d.RequestDates
                        .Select(k => k.Date)
                        .Where(d => d.Date >= request.Start && d.Date <= request.End))
                    .ToList();

                var vacationRequest = this.requestFactory
                    .WithPeriod(request.Start, request.End)
                    .WithDays(request.Start, request.End)
                    .WithApprover(approverId)
                    .WithRequesterComment(request.RequesterComment)
                    .WithPTOBalance(pTOBalance)
                    .WithRequestDates(
                        type,
                        request.Hours,
                        request.ExcludeHolidays,
                        request.ExcludeWeekends,
                        holidays,
                        requestedDates)
                    .WithOptions(
                        false, 
                        request.IsPlanning, 
                        request.ExcludeHolidays, 
                        request.ExcludeWeekends)
                    .Build();

                requester.AddRequest(vacationRequest);

                await this.requestDomainRepository.Save(vacationRequest, cancellationToken);

                return new CreateRequestOutputModel(vacationRequest.Id);
            }
        }
    }
}
