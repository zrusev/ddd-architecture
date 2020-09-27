namespace TimeOffManager.Domain.Vacations.Factories.Requesters
{
    using Common;
    using Models.Requesters;

    public interface IRequesterFactory : IFactory<Requester>
    {
        IRequesterFactory WithFirstName(string firstName);

        IRequesterFactory WithLastName(string lastName);

        IRequesterFactory WithLastEmployeeId(string employeeId);

        IRequesterFactory WithEmail(string email);

        public IRequesterFactory WithImageUrl(string imageUrl);

        IRequesterFactory WithManager(Employee manager);

        IRequesterFactory WithTeam(Team team);
    }
}
