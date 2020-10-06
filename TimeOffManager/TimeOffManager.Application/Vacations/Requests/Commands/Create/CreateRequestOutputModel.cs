namespace TimeOffManager.Application.Vacations.Requests.Commands.Create
{
    public class CreateRequestOutputModel
    {
        public CreateRequestOutputModel(int requesterId)
            => this.RequestId = requesterId;

        public int RequestId { get; }
    }
}
