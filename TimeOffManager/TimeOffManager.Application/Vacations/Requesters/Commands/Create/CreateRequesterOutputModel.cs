namespace TimeOffManager.Application.Vacations.Requesters.Commands.Create
{
    public class CreateRequesterOutputModel
    {
        public CreateRequesterOutputModel(int requesterId)
            => this.RequesterId = requesterId;

        public int RequesterId { get; }
    }
}