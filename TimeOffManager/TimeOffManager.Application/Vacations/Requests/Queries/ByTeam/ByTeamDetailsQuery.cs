namespace TimeOffManager.Application.Vacations.Requests.Queries.ByTeam
{
    using Common;
    using MediatR;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Vacations.Requesters;

    public class ByTeamDetailsQuery : EntityCommand<int>, IRequest<IEnumerable<ByTeamDetailsOutputModel>>
    {
        public class ByTeamDetailsQueryHandler : IRequestHandler<ByTeamDetailsQuery, IEnumerable<ByTeamDetailsOutputModel>>
        {
            private readonly IRequesterQueryRepository requesterQueryRepository;

            public ByTeamDetailsQueryHandler(IRequesterQueryRepository requesterQueryRepository)
                => this.requesterQueryRepository = requesterQueryRepository;
            
            public async Task<IEnumerable<ByTeamDetailsOutputModel>> Handle(
                ByTeamDetailsQuery request, 
                CancellationToken cancellationToken)
            {
                var requesters = await this.requesterQueryRepository.GetDetailsByTeamId(
                    request.Id,
                    cancellationToken);

                var requests = new List<ByTeamDetailsOutputModel>();
                
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
                        .Select(date => new ByTeamRequestDateDetailsModel(
                            date.RequestType.Name,
                            date.Hours,
                            date.Date))
                        .ToList();

                    requests.Add(
                        new ByTeamDetailsOutputModel(
                            requester.FirstName,
                            requester.LastName,
                            requester.Manager!,
                            requester.Team!,
                            dates));
                }

                return requests;
            }
        }
   }
}