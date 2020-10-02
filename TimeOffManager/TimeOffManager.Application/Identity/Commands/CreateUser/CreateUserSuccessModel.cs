namespace TimeOffManager.Application.Identity.Commands.CreateUser
{
    public class CreateUserSuccessModel
    {
        public CreateUserSuccessModel(string requesterId)
        {
            this.RequesterId = requesterId;
        }

        public string RequesterId { get; set; }
    }
}
