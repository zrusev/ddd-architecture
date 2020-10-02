namespace TimeOffManager.Application.Identity.Commands.CreateUser
{
    using Common;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateUserCommand : UserInputModel, IRequest<Result<CreateUserSuccessModel>>
    {
        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<CreateUserSuccessModel>>
        {
            private readonly IIdentity identity;

            public CreateUserCommandHandler(IIdentity identity)
                => this.identity = identity;

            public async Task<Result<CreateUserSuccessModel>> Handle(
                CreateUserCommand request,
                CancellationToken cancellationToken)
                => await this.identity.Register(request);
        }
    }
}