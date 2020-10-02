namespace TimeOffManager.Application.Vacations.Requesters.Queries.Common
{
    using Application.Common.Mapping;
    using AutoMapper;
    using Domain.Vacations.Models.Requesters;

    public class RequesterOutputModel : IMapFrom<Requester>
    {
        public int Id { get; private set; }

        public string FirstName { get; private set; } = default!;

        public string LastName { get; private set; } = default!;

        public string EmployeeId { get; private set; } = default!;

        public string Email { get; private set; } = default!;

        public string ImageUrl { get; private set; } = default!;

        public Employee? Manager { get; private set; } = default!;

        public Team? Team { get; private set; } = default!;

        public virtual void Mapping(Profile mapper)
            => mapper
                .CreateMap<Requester, RequesterOutputModel>()
                .ForMember(d => d.FirstName, cfg => cfg
                    .MapFrom(d => d.Employee.FirstName))
                .ForMember(d => d.LastName, cfg => cfg
                    .MapFrom(d => d.Employee.LastName))
                .ForMember(d => d.EmployeeId, cfg => cfg
                    .MapFrom(d => d.Employee.EmployeeId))
                .ForMember(d => d.Email, cfg => cfg
                    .MapFrom(d => d.Employee.Email))
                .ForMember(d => d.ImageUrl, cfg => cfg
                    .MapFrom(d => d.Employee.ImageUrl))
                .ForMember(d => d.Manager, cfg => cfg
                    .MapFrom(d => d.Employee.Manager))
                .ForMember(d => d.Team, cfg => cfg
                    .MapFrom(d => d.Employee.Team));
    }
}
