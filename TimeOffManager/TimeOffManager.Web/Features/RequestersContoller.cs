namespace TimeOffManager.Web.Features
{
    using Application.Identity.Commands.CreateUser;
    using Application.Vacations.Requesters.Commands.Create;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class RequestersContoller : ApiController
    {
        [HttpPost]
        [Route(nameof(Create))]
        public async Task<ActionResult<CreateRequesterOutputModel>> Create(
            CreateRequesterCommand command)
            => await this.Send(command);
    }
}
