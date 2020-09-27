namespace TimeOffManager.Application.Identity
{
    using Domain.Vacations.Models.Requesters;
    
    public interface IUser
    {
        void BecomeRequester(Requester requester);
    }
}