using KometSales.Application.UserRoles.Queries;
using KometSales.Common.Entities.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KometSales.Api.Controllers
{
    /// <summary>
    /// User roles controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrator")]
    public class UserRolesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserRolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Gets roles list
        /// </summary>
        /// <returns>List of roles</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<UserRolDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<List<UserRolDto>> Get()
        {
            return await _mediator.Send(new GetUserRolesQueryHandler.Query());
        }
    }
}
