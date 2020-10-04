namespace TimeOffManager.Application.Identity.Commands.LoginUser
{
    using Common;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using Vacations.Requesters;

    public class LoginUserCommand : UserInputModel, IRequest<Result<LoginOutputModel>>
    {
        public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, Result<LoginOutputModel>>
        {
            private readonly IIdentity identity;
            private readonly IRequesterQueryRepository repository;

            public LoginUserCommandHandler(
                IIdentity identity,
                IRequesterQueryRepository repository
                )
            {
                this.identity = identity;
                this.repository = repository;
            }

            public async Task<Result<LoginOutputModel>> Handle(
                LoginUserCommand request,
                CancellationToken cancellationToken
                )
            {
                var result = await this.identity.Login(request);

                if (!result.Succeeded)
                {
                    return result.Errors;
                }

                var user = result.Data;

                var requesterId = await this.repository.GetRequesterId(user.UserId, cancellationToken);

                return new LoginOutputModel(user.Token, requesterId);
            }
        }
    }
}