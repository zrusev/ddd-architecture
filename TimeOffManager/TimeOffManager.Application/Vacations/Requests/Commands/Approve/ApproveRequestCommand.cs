namespace TimeOffManager.Application.Vacations.Requests.Commands.Approve
{
    using Common;
    using Common.Contracts;
    using Common.Entities;
    using Domain.Vacations.Exceptions;
    using Domain.Vacations.Models.Shared;
    using Domain.Vacations.Repositories;
    using Domain.Vacations.Services;
    using MediatR;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Vacations.Requesters;
    using Vacations.Requests.Queries;

    public class ApproveRequestCommand : EntityCommand<int>, IRequest<Result>
    {
        public bool IsApproved { get; set; }

        public string? ApproverComment { get; set; }

        public DateTime RevisedOn { get; } = DateTime.Now;

        public class ApproveRequestCommandHandler : IRequestHandler<ApproveRequestCommand, Result>
        {
            private const string InvalidApproverMessage = "You are not allowed to approve this request.";
            private const string DuplicateApprovalMessage = "This request has already been approved.";
            private const string RequestSubject = "Request approval";
            private const string RequestBody = "Your request has been ";

            private readonly ICurrentUser currentUser;
            private readonly IRequesterQueryRepository requesterQueryRepository;
            private readonly IRequestQueryRepository requestQueryRepository;
            private readonly IRequestDomainRepository requestDomainRepository;
            private readonly IRequesterDomainRepository requesterDomainRepository;
            private readonly ICurrentBalanceService currentBalanceService;
            private readonly IMailer mailer;

            public ApproveRequestCommandHandler(
                ICurrentUser currentUser,
                IRequesterQueryRepository requesterQueryRepository,
                IRequestQueryRepository requestQueryRepository,
                IRequestDomainRepository requestDomainRepository,
                IRequesterDomainRepository requesterDomainRepository,
                ICurrentBalanceService currentBalanceService,
                IMailer mailer
                )
            {
                this.currentUser = currentUser;
                this.requesterQueryRepository = requesterQueryRepository;
                this.requestQueryRepository = requestQueryRepository;
                this.requestDomainRepository = requestDomainRepository;
                this.requesterDomainRepository = requesterDomainRepository;
                this.currentBalanceService = currentBalanceService;
                this.mailer = mailer;
            }

            public async Task<Result> Handle(
                ApproveRequestCommand request, 
                CancellationToken cancellationToken
                )
            {
                var approver = await this.requesterQueryRepository.FindByUser(
                    this.currentUser.UserId,
                    cancellationToken);

                var requestDetails = await this.requestQueryRepository.GetRequest(
                    request.Id,
                    cancellationToken);

                if (requestDetails.ApproverId != approver.Id)
                    throw new InvalidApproverException(InvalidApproverMessage);

                if (requestDetails.Options.IsApproved)
                    throw new InvalidApproverException(DuplicateApprovalMessage);

                var requester = await this.requesterQueryRepository.GetRequesterByRequestId(
                    request.Id,
                    cancellationToken);

                var requesterModel = await this.requesterQueryRepository.GetDetailsWithRequests(
                    requester.Id,
                    cancellationToken);

                var lastRequestedDates = requesterModel
                    .Requests
                    .Where(r => r.Options.IsApproved)
                    .SelectMany(d => d.RequestDates)
                    .GroupBy(g => g.Date)
                    .SelectMany(d => d
                        .Where(d => d.Date >= requestDetails.DateTimeRange.Start && 
                            d.Date <= requestDetails.DateTimeRange.End)
                        .OrderByDescending(r => r.Id)
                        .Take(1))                  
                    .Select(model => new RequestDateDetailsModel(model.RequestType.Name, model.Date))
                    .ToList();

                var currentBalance = requester
                    .Employee.PTOBalance!.Current ?? 0;

                var newBalance = this.currentBalanceService.Calculate(
                    currentBalance,
                    requestDetails.RequestDates,
                    lastRequestedDates);
                
                requestDetails
                    .UpdateApprover(approver.Id)
                    .UpdateApproverComment(request.ApproverComment)
                    .UpdateIsApproved(request.IsApproved)
                    .UpdateRevisedOn(request.RevisedOn)
                    .UpdateUpdatedPTOBalance(
                        requester.Employee.PTOBalance.Initial,
                        requester.Employee.PTOBalance.Current,
                        newBalance);

                requester
                    .UpdatePTOBalance(
                        requester.Employee.PTOBalance.Initial,
                        newBalance, 
                        requester.Employee.PTOBalance.Updated);

                await this.requesterDomainRepository.Save(requester, cancellationToken);

                await this.requestDomainRepository.Save(requestDetails, cancellationToken);

                await mailer.SendEmailAsync(
                    new MailOutputModel(
                        requester.Employee.FirstName + " " + requester.Employee.LastName,
                        requester.Employee.Email,
                        RequestSubject,
                        RequestBody + (request.IsApproved ? "approved" : "rejected")
                        ));

                return Result.Success;
            }
        }
    }
}