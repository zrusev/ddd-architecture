namespace TimeOffManager.Application.Vacations.Requesters.Queries.Common
{
    using Application.Common.Mapping;
    using AutoMapper;
    using Domain.Vacations.Models.Requesters;

    public class TeamOutputModell : IMapFrom<Requester>
    {
        public int Id { get; private set; }

        public Team Team { get; private set; } = default!;

        public virtual void Mapping(Profile mapper)
            => mapper
                .CreateMap<Requester, TeamOutputModell>()
                .ForMember(d => d.Team, cfg => cfg
                    .MapFrom(d => d.Employee.Team));
    }
}
