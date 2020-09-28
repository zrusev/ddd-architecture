namespace TimeOffManager.Application.Identity.Commands.CreateUser
{
    using Common;
    using Domain.Vacations.Factories.Requesters;
    using Domain.Vacations.Models.Requesters;
    using Domain.Vacations.Repositories;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    
    public class CreateUserCommand : UserInputModel, IRequest<Result>
    {
        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;

        public string EmployeeId { get; set; } = default!;

        public string ImageUrl { get; set; } = default!;

        public Employee Manager { get; set; } = default!;

        public Team Team { get; set; } = default!;

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result>
        {
            private readonly IIdentity identity;
            private readonly IRequesterFactory requesterFactory;
            private readonly IRequesterRepository requesterRepository;

            public CreateUserCommandHandler(
                IIdentity identity,
                IRequesterFactory requesterFactory,
                IRequesterRepository requesterRepository
                )
            {
                this.identity = identity;
                this.requesterFactory = requesterFactory;
                this.requesterRepository = requesterRepository;
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

                var requester = this.requesterFactory
                    .WithFirstName(request.FirstName)
                    .WithLastName(request.LastName)
                    .WithEmployeeId(request.EmployeeId)
                    .WithEmail(request.Email)
                    .WithImageUrl(request.ImageUrl)
                    .WithManager(request.Manager)
                    .WithTeam(request.Team)
                    .Build();

                user.BecomeRequester(requester);

                await this.requesterRepository.Save(requester, cancellationToken);

                return result;
            }
        }
    }
}
