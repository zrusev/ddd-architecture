namespace TimeOffManager.Application.Vacations.Requests.Queries.Details
{
    using Common;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class RequestDetailsQuery : EntityCommand<int>, IRequest<RequestDetailsOutputModel>
    {
        public class RequestDetailsQueryHandler : IRequestHandler<RequestDetailsQuery, RequestDetailsOutputModel>
        {
            private readonly IRequestQueryRepository requestQueryRepository;

            public RequestDetailsQueryHandler(
                IRequestQueryRepository requestQueryRepository
                )
            {
                this.requestQueryRepository = requestQueryRepository;
            }

            public async Task<RequestDetailsOutputModel> Handle(
                RequestDetailsQuery request, 
                CancellationToken cancellationToken)
            => await this.requestQueryRepository.GetDetails(
                    request.Id,
                    cancellationToken);

            //ToDo: Include Approver details to RequestDetailsOutputModel
        }
    }
}