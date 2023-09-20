using AutoMapper;
using KometSales.Application.Users.Commands;
using KometSales.Application.Users.Queries;
using KometSales.Common.Entities.Dtos;
using KometSales.Common.Entities.Models;
using KometSales.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KometSales.Api.Controllers
{
    /// <summary>
    /// Users controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrator")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UsersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets users list
        /// </summary>
        /// <returns>List of Users</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<UserDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<List<UserDto>> Get()
        {
            return await _mediator.Send(new GetUsersQueryHandler.Query());
        }

        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="model">Create user model</param>
        /// <returns>Unit</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<Unit> Create([FromBody] CreateUserModel model)
        {
            var command = _mapper.Map<CreateUserCommandHandler.Command>(model);
            return await _mediator.Send(command);
        }

        /// <summary>
        /// Updates a user
        /// </summary>
        /// <param name="model">Update user model</param>
        /// <returns>Unit</returns>
        [HttpPut("{userId}")]
        [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<Unit> Update([FromRoute] Guid userId, [FromBody] UpdateUserModel model)
        {
            var command = _mapper.Map<UpdateUserCommandHandler.Command>(model);
            command.UserId = userId;
            return await _mediator.Send(command);
        }

        /// <summary>
        /// Deletes a user
        /// </summary>
        /// <param name="userId">User identifier</param>
        /// <returns>Unit</returns>
        [HttpDelete("{userId}")]
        [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<Unit> Delete([FromRoute] Guid userId)
        {
            var command = new DeleteUserCommandHandler.Command()
            {
                UserId = userId
            };
            return await _mediator.Send(command);
        }
    }
}
