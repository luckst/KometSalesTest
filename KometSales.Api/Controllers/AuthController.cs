using KometSales.Api.Services;
using KometSales.Application.Users.Commands;
using KometSales.Common.Entities.Dtos;
using KometSales.Common.Entities.Models;
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
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var command = new ValidateUserCommandHandler.Command()
            {
                Password = model.Password,
                UserName = model.UserName
            };

            var (validUser, userRol) = await _mediator.Send(command);

            if (validUser)
            {
                var token = _tokenGenerator.GenerateToken(model.UserName, userRol);
                return Ok(new TokenDto{ Token = token });
            }

            return Unauthorized();
        }
    }
}
