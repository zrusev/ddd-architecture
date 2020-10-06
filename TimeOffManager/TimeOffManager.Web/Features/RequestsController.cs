namespace TimeOffManager.Web.Features
{
    using Application.Vacations.Requests.Commands.Create;
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
    }
}