namespace TimeOffManager.Application.Vacations.Requests.Queries.ByTeam
{
    using Common;
    using MediatR;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Vacations.Requesters;

    public class ByTeamDetailsQuery : EntityCommand<int>, IRequest<ByTeamDetailsOutputModel>
    {
        public class ByTeamDetailsQueryHandler : IRequestHandler<ByTeamDetailsQuery, ByTeamDetailsOutputModel>
        {
            private readonly IRequesterQueryRepository requesterQueryRepository;

            public ByTeamDetailsQueryHandler(
                IRequesterQueryRepository requesterQueryRepository
                )
            {
                this.requesterQueryRepository = requesterQueryRepository;
            }

            public async Task<ByTeamDetailsOutputModel> Handle(
                ByTeamDetailsQuery request, 
                CancellationToken cancellationToken)
            {
                var requesters = await this.requesterQueryRepository.GetDetailsByTeamId(
                    request.Id,
                    cancellationToken);

                ByTeamDetailsOutputModel model = new ByTeamDetailsOutputModel();
                
                foreach (var requester in requesters)
                {
                    var dates = requester
                        .Requests
                        .Where(r => r.Options.IsApproved)
                        .SelectMany(d => d.RequestDates)
                        .GroupBy(g => g.Date)
                        .SelectMany(d => d
                            .Where(d => d.Date.Year == DateTime.Now.Year)
                            .OrderByDescending(r => r.Id)
                            .Take(1))
                        .Select(d => new DetailsOutputModel(
                            requester.FirstName,
                            requester.LastName,  
                            d.RequestType.Name, 
                            d.Date 
                        ))
                        .ToList();

                    model.Requesters.Add(dates);
                }

                return model;
            }
        }
    }
}