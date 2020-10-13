namespace TimeOffManager.Application.Vacations.Requesters.Commands.Edit
{
    using Application.Common;
    using Application.Common.Contracts;
    using Domain.Vacations.Exceptions;
    using Domain.Vacations.Repositories;
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class EditRequesterCommand : EntityCommand<int>,  IRequest<Result>
    {
        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;

        public string EmployeeId { get; set; } = default!;

        public string ImageUrl { get; set; } = default!;

        public DateTime HireDate { get; set; } = default;

        public DateTime? LeaveDate { get; set; } = default;

        public int? Initial { get; set; } = default;

        public int? Current { get; set; } = default;

        public int? Updated { get; set; } = default;

        public int ManagerId { get; set; } = default;

        public string TeamName { get; set; } = default!;

        public class EditRequesterCommandHandler : IRequestHandler<EditRequesterCommand, Result>
        {
            private readonly ICurrentUser currentUser;
            private readonly IRequesterDomainRepository requesterRepository;
            private readonly IRequesterQueryRepository requesterQueryRepository;

            public EditRequesterCommandHandler(
                ICurrentUser currentUser,
                IRequesterDomainRepository requesterRepository,
                IRequesterQueryRepository requesterQueryRepository
                )
            {
                this.currentUser = currentUser;
                this.requesterRepository = requesterRepository;
                this.requesterQueryRepository = requesterQueryRepository;
            }

            public async Task<Result> Handle(
                EditRequesterCommand request,
                CancellationToken cancellationToken
                )
            {
                var requester = await this.requesterQueryRepository.FindByUser(
                    this.currentUser.UserId,
                    cancellationToken);

                if (request.Id != requester.Id)
                    throw new InvalidRequesterException("You cannot edit this requester.");

                var manager = await this.requesterQueryRepository.FindByManagerId(request.ManagerId);

                var team = await this.requesterQueryRepository.FindByTeamName(request.TeamName);

                requester.Employee
                    .UpdateFirstName(request.FirstName)
                    .UpdateLastName(request.LastName)
                    .UpdateEmployeeId(request.EmployeeId)
                    .UpdateEmail(this.currentUser.UserEmail)
                    .UpdateHireDate(request.HireDate)
                    .UpdateLeaveDate(request.LeaveDate)
                    .UpdatePTOBalance(request.Initial, request.Current, request.Updated)
                    .UpdateManager(manager)
                    .UpdateTeam(team);

                await this.requesterRepository.Save(requester, cancellationToken);

                return Result.Success;
            }
        }
    }
}