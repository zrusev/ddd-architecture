namespace TimeOffManager.Application.Identity.Commands.CreateUser
{
    public class CreateUserSuccessModel
    {
        public CreateUserSuccessModel(string token)
            => this.Token = token;

        public string Token { get; set; }
    }
}
