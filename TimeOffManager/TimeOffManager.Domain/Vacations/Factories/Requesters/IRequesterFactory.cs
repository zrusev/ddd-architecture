namespace TimeOffManager.Domain.Vacations.Factories.Requesters
{
    using Common;
    using Models.Requesters;
    using System;

    public interface IRequesterFactory : IFactory<Requester>
    {
        IRequesterFactory WithFirstName(string firstName);

        IRequesterFactory WithLastName(string lastName);

        IRequesterFactory WithEmployeeId(string employeeId);

        IRequesterFactory WithEmail(string email);

        IRequesterFactory WithImageUrl(string imageUrl);

        IRequesterFactory WithManager(Employee? manager);

        IRequesterFactory WithTeam(Team team);

        IRequesterFactory WithTeam(string name);
        
        IRequesterFactory WithPTOBalance(int? initial, int? current);

        IRequesterFactory WithHireDate(DateTime? hireDate);

        IRequesterFactory WithLeaveDate(DateTime? leaveDate);

        IRequesterFactory FromUser(string userId);
    }
}
