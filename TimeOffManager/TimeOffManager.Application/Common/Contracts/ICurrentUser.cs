namespace TimeOffManager.Application.Common.Contracts
{
    public interface ICurrentUser
    {
        string UserId { get; }

        string UserEmail { get; }
    }
}
