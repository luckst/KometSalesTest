using AutoMapper;
using KometSales.Application.Customers.Commands;
using KometSales.Application.Customers.Queries;
using KometSales.Common.Entities.Dtos;
using KometSales.Common.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KometSales.Api.Controllers
{
    /// <summary>
    /// customers controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrator")]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CustomersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets customers list
        /// </summary>
        /// <returns>List of customers</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<CustomerDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<List<CustomerDto>> Get()
        {
            return await _mediator.Send(new GetCustomersQueryHandler.Query());
        }

        /// <summary>
        /// Search for customers
        /// </summary>
        /// <param name="filter">Filter</param>
        /// <returns>List of customers</returns>
        [Authorize(Roles = "Administrator,Sales")]
        [HttpGet("search")]
        [ProducesResponseType(typeof(List<CustomerDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<List<CustomerDto>> Search(string? filter)
        {
            return await _mediator.Send(new SearchCustomersQueryHandler.Query() { Filter = filter});
        }

        /// <summary>
        /// Creates a new customer
        /// </summary>
        /// <param name="model">Create customer model</param>
        /// <returns>Unit</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<Unit> Create([FromBody] CustomerModel model)
        {
            var command = _mapper.Map<CreateCustomerCommandHandler.Command>(model);
            return await _mediator.Send(command);
        }

        /// <summary>
        /// Updates a customer
        /// </summary>
        /// <param name="model">Update customer model</param>
        /// <returns>Unit</returns>
        [HttpPut("{customerId}")]
        [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<Unit> Update([FromRoute] Guid customerId, [FromBody] CustomerModel model)
        {
            var command = _mapper.Map<UpdateCustomerCommandHandler.Command>(model);
            command.CustomerId = customerId;
            return await _mediator.Send(command);
        }

        /// <summary>
        /// Deletes a customer
        /// </summary>
        /// <param name="customerId">customer identifier</param>
        /// <returns>Unit</returns>
        [HttpDelete("{customerId}")]
        [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<Unit> Delete([FromRoute] Guid customerId)
        {
            var command = new DeleteCustomerCommandHandler.Command()
            {
                CustomerId = customerId
            };
            return await _mediator.Send(command);
        }
    }
}
