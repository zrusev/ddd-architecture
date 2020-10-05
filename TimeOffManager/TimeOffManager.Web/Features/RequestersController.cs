namespace TimeOffManager.Web.Features
{
    using Application.Common;
    using Application.Vacations.Requesters.Commands.Create;
    using Application.Vacations.Requesters.Commands.Edit;
    using Application.Vacations.Requesters.Queries.Common;
    using Application.Vacations.Requesters.Queries.Details;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class RequestersController : ApiController
    {
        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<RequesterOutputModel>> Details(
            [FromRoute] RequsterDetailsQuery query)
            => await this.Send(query);

        [HttpPost]
        [Authorize]
        [Route(nameof(Create))]
        public async Task<ActionResult<CreateRequesterOutputModel>> Create(
            CreateRequesterCommand command)
            => await this.Send(command);

        [HttpPut]
        [Authorize]
        [Route(Id)]
        public async Task<ActionResult> Edit(
            int id,
            EditRequesterCommand command)
            => await this.Send(command.SetId(id));
    }
}