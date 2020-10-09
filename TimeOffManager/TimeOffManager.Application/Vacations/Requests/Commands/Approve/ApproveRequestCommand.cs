namespace TimeOffManager.Application.Vacations.Requests.Commands.Approve
{
    using Common;
    using Common.Contracts;
    using Domain.Vacations.Repositories;
    using MediatR;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Vacations.Requesters;
    using Vacations.Requests.Queries;

    public class ApproveRequestCommand : EntityCommand<int>, IRequest<Result>
    {
        public bool IsApproved { get; set; } //can decline as well

        public string? ApproverComment { get; set; }

        public DateTime ApprovedOn { get; } = DateTime.Now;

        public class ApproveRequestCommandHandler : IRequestHandler<ApproveRequestCommand, Result>
        {
            private readonly ICurrentUser currentUser;
            private readonly IRequesterQueryRepository requesterQueryRepository;
            private readonly IRequestQueryRepository requestQueryRepository;
            private readonly IRequestDomainRepository requestDomainRepository;
            private readonly IRequesterDomainRepository requesterDomainRepository;

            public ApproveRequestCommandHandler(
                ICurrentUser currentUser,
                IRequesterQueryRepository requesterQueryRepository,
                IRequestQueryRepository requestQueryRepository,
                IRequestDomainRepository requestDomainRepository,
                IRequesterDomainRepository requesterDomainRepository
                )
            {
                this.currentUser = currentUser;
                this.requesterQueryRepository = requesterQueryRepository;
                this.requestQueryRepository = requestQueryRepository;
                this.requestDomainRepository = requestDomainRepository;
                this.requesterDomainRepository = requesterDomainRepository;
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

                var requestTypeName = requestDetails
                    .RequestDates
                    .FirstOrDefault(s => !(s.RequestType is null))
                    .RequestType.Name;

                //You can add a check whether my manager is the approver or can be anyone

                requestDetails
                    .UpdateApprover(approver.Id)
                    .UpdateApproverComment(request.ApproverComment)
                    .UpdateIsApproved(request.IsApproved)
                    .UpdateApprovedOn(request.ApprovedOn)
                    .UpdateUpdatedPTOBalance(requestTypeName);

                var requester = await this.requesterQueryRepository.GetRequesterByRequestId(
                    requestDetails.Id,
                    cancellationToken);

                requester
                    .UpdatePTOBalance(requestDetails.PTOBalance);

                await this.requesterDomainRepository.Save(requester, cancellationToken);

                await this.requestDomainRepository.Save(requestDetails, cancellationToken);

                return Result.Success;
            }
        }
    }
}