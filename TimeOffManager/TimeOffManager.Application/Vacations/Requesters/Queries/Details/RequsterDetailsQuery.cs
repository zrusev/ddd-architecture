namespace TimeOffManager.Application.Vacations.Requesters.Queries.Details
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using Vacations.Requesters.Queries.Common;

    public class RequsterDetailsQuery : IRequest<RequesterOutputModel>
    {
        public int Id { get; set; }

        public class RequsterDetailsQueryHandler : IRequestHandler<RequsterDetailsQuery, RequesterOutputModel>
        {
            private readonly IRequesterQueryRepository requesterQueryRepository;

            public RequsterDetailsQueryHandler(IRequesterQueryRepository requesterQueryRepository)
                => this.requesterQueryRepository = requesterQueryRepository;

            public async Task<RequesterOutputModel> Handle(
                RequsterDetailsQuery request,
                CancellationToken cancellationToken)
                => await this.requesterQueryRepository.GetDetails(request.Id, cancellationToken);
        }
    }
}