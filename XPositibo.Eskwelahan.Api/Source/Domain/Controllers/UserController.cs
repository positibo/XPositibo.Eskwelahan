using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using XPositibo.Eskwelahan.Api.Source.Domain.UseCases.Queries.Users;

namespace XPositibo.Eskwelahan.Api.Source.Domain.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator) => this.mediator = mediator;

        [HttpGet("{id}")]
        public async Task<ActionResult<GetUserByIdDto>> GetUserById(int id)
        {
            var result = await mediator.Send(new GetUserByIdQuery(id));

            return Ok(result);
        }
    }
}
