using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using XPositibo.Eskwelahan.Api.Source.Domain.UseCases.Command.Authentication.Login;
using XPositibo.Eskwelahan.Api.Source.Domain.UseCases.Command.Authentication.RegisterUser;

namespace XPositibo.Eskwelahan.Api.Source.Domain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthenticationController(IMediator mediator) => this.mediator = mediator;

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var loginResult = await mediator.Send(new LoginCommand(dto));

            return Ok(loginResult);
        }


        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDto dto)
        {
            await mediator.Send(new RegisterUserCommand(dto));

            return Ok();
        }
    }
}
