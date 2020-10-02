namespace TimeOffManager.Application.Identity.Commands.CreateUser
{
    using Common;
    using Domain.Vacations.Factories.Requesters;
    using Domain.Vacations.Repositories;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using Vacations.Requesters;

    public class CreateUserCommand : UserInputModel, IRequest<Result>
    {
        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;

        public string EmployeeId { get; set; } = default!;

        public string ImageUrl { get; set; } = default!;

        public int ManagerId { get; set; } = default!;

        public int TeamId { get; set; } = default!;

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result>
        {
            private readonly IIdentity identity;
            private readonly IRequesterFactory requesterFactory;
            private readonly IRequesterDomainRepository requesterRepository;
            private readonly IRequesterQueryRepository requesterQueryRepository;

            public CreateUserCommandHandler(
                IIdentity identity,
                IRequesterFactory requesterFactory,
                IRequesterDomainRepository requesterRepository,
                IRequesterQueryRepository requesterQueryRepository
                )
            {
                this.identity = identity;
                this.requesterFactory = requesterFactory;
                this.requesterRepository = requesterRepository;
                this.requesterQueryRepository = requesterQueryRepository;
            }

            public async Task<Result> Handle(
                CreateUserCommand request,
                CancellationToken cancellationToken)
            {
                var result = await this.identity.Register(request);

                if (!result.Succeeded)
                {
                    return result;
                }

                var user = result.Data;

                var manager = await this.requesterQueryRepository.FindByManagerId(request.ManagerId);

                var team = await this.requesterQueryRepository.FindByTeamId(request.TeamId);

                var requester = this.requesterFactory
                    .WithFirstName(request.FirstName)
                    .WithLastName(request.LastName)
                    .WithEmployeeId(request.EmployeeId)
                    .WithEmail(request.Email)
                    .WithImageUrl(request.ImageUrl)
                    .WithManager(manager)
                    .WithTeam(team)
                    .Build();

                user.BecomeRequester(requester);

                await this.requesterRepository.Save(requester, cancellationToken);

                return result;
            }
        }
    }
}