using KometSales.Api.Services;
using KometSales.Application.Users.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KometSales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ITokenGenerator _tokenGenerator;

        public AuthController(IMediator mediator, ITokenGenerator tokenGenerator)
        {
            _mediator = mediator;
            _tokenGenerator = tokenGenerator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            var command = new ValidateUserCommandHandler.Command()
            {
                Password = password,
                UserName = username
            };

            var (validUser, userRol) = await _mediator.Send(command);

            if (validUser)
            {
                var token = _tokenGenerator.GenerateToken(username, userRol);
                return Ok(new { Token = token });
            }

            return Unauthorized();
        }
    }
}
