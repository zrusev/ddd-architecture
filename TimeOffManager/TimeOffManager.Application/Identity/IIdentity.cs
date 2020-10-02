namespace TimeOffManager.Application.Identity
{
    using Commands;
    using Commands.ChangePassword;
    using Commands.LoginUser;
    using Common;
    using Identity.Commands.CreateUser;
    using System.Threading.Tasks;

    public interface IIdentity
    {
        Task<Result<CreateUserSuccessModel>> Register(UserInputModel userInput);

        Task<Result<LoginSuccessModel>> Login(UserInputModel userInput);

        Task<Result> ChangePassword(ChangePasswordInputModel changePasswordInput);
    }
}
