namespace TimeOffManager.Application.Identity.Commands.CreateUser
{
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
    using MediatR;

    public class CreateUserCommand : UserInputModel, IRequest<Result>
    {
        public string Name { get; set; } = default!;

        public string PhoneNumber { get; set; } = default!;

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result>
        {
            private readonly IIdentity identity;

            public CreateUserCommandHandler(
                IIdentity identity)
            {
                this.identity = identity;
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

                return result;
            }
        }
    }
}
