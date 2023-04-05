using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Application.CQRS.Users.Commands.CreateUser;
using Sat.Recruitment.Application.CQRS.Users.Queries.GetUserById;
using Sat.Recruitment.WebUI.Controllers;

namespace Sat.Recruitment.Api.Controllers
{
    public class UserController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateUserCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet]
        [Route("{Id:int}")]
        public async Task<ActionResult<GetUserByIdDto>> Get(int Id)
        {
            return await Mediator.Send(new GetUserByIdQuery(Id));
        }
    }
}
