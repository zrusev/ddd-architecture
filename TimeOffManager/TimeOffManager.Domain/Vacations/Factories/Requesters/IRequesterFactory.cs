namespace TimeOffManager.Domain.Vacations.Factories.Requesters
{
    using Common;
    using Models.Requesters;

    public interface IRequesterFactory : IFactory<Requester>
    {
        IRequesterFactory WithEmployee(Employee employee);

        IRequesterFactory WithTeam(Team team);

    }
}
