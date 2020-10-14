namespace TimeOffManager.Application.Vacations.Requesters.Commands.Create
{
    using Common.Contracts;
    using Domain.Vacations.Exceptions;
    using Domain.Vacations.Factories.Requesters;
    using Domain.Vacations.Repositories;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using Vacations.Requesters;

    public class CreateRequesterCommand : IRequest<CreateRequesterOutputModel>
    {
        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;

        public string EmployeeId { get; set; } = default!; //domain property not a reference ID

        public string ImageUrl { get; set; } = default!;

        public int? PTOInitial { get; set; }

        public int? PTOCurrent { get; set; }

        public int ManagerId { get; set; } = default;

        public string TeamName { get; set; } = default!;

        public class CreateRequesterCommandHandler : IRequestHandler<CreateRequesterCommand, CreateRequesterOutputModel>
        {
            private const string DuplicateRegistrationMessage = "Requester has already been registered.";

            private readonly ICurrentUser currentUser;
            private readonly IRequesterFactory requesterFactory;
            private readonly IRequesterDomainRepository requesterRepository;
            private readonly IRequesterQueryRepository requesterQueryRepository;

            public CreateRequesterCommandHandler(
                ICurrentUser currentUser,
                IRequesterFactory requesterFactory,
                IRequesterDomainRepository requesterRepository,
                IRequesterQueryRepository requesterQueryRepository
                )
            {
                this.currentUser = currentUser;
                this.requesterFactory = requesterFactory;
                this.requesterRepository = requesterRepository;
                this.requesterQueryRepository = requesterQueryRepository;
            }

            public async Task<CreateRequesterOutputModel> Handle(
                CreateRequesterCommand request,
                CancellationToken cancellationToken
                )
            {
                var user = await this.requesterQueryRepository.FindByUser(this.currentUser.UserId);

                if (!(user is null))
                    throw new InvalidRequesterException(DuplicateRegistrationMessage);

                var manager = await this.requesterQueryRepository
                    .FindByManagerId(request.ManagerId);

                var team = await this.requesterQueryRepository
                    .FindByTeamName(request.TeamName);

                var factory = team == null
                    ? this.requesterFactory.WithTeam(request.TeamName)
                    : this.requesterFactory.WithTeam(team);

                var requester = factory
                    .WithFirstName(request.FirstName)
                    .WithLastName(request.LastName)
                    .WithEmployeeId(request.EmployeeId)
                    .WithEmail(this.currentUser.UserEmail)
                    .WithImageUrl(request.ImageUrl)
                    .WithPTOBalance(request.PTOInitial, request.PTOCurrent)
                    .WithManager(manager)
                    .FromUser(this.currentUser.UserId)
                    .Build();

                await this.requesterRepository.Save(requester, cancellationToken);

                return new CreateRequesterOutputModel(requester.Id);
            }
        }
    }
}