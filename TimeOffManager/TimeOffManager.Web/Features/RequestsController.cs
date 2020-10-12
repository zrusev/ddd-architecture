namespace TimeOffManager.Web.Features
{
    using Application.Common;
    using Application.Vacations.Requests.Commands.Approve;
    using Application.Vacations.Requests.Commands.Create;
    using Application.Vacations.Requests.Queries.ByTeam;
    using Application.Vacations.Requests.Queries.Details;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class RequestsController : ApiController
    {
        [HttpPost]
        [Authorize]
        [Route(nameof(Create))]
        public async Task<ActionResult<CreateRequestOutputModel>> Create(
            [FromBody] CreateRequestCommand command)
            => await this.Send(command);

        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<RequestDetailsOutputModel>> Details(
            [FromRoute] RequestDetailsQuery query)
            => await this.Send(query);

        [HttpGet]
        [Route(nameof(Teams) + PathSeparator + Id)]
        public async Task<ActionResult<ByTeamDetailsOutputModel>> Teams(
            [FromRoute] ByTeamDetailsQuery query)
            => await this.Send(query);

        [HttpPut]
        [Authorize]
        [Route(Id)]
        public async Task<ActionResult> Approve(
            int id,
            ApproveRequestCommand command)
            => await this.Send(command.SetId(id));
    }
}