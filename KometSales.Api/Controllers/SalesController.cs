using AutoMapper;
using KometSales.Application.Sales.Commands;
using KometSales.Common.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KometSales.Api.Controllers
{
    /// <summary>
    /// Sales controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Sales")]
    public class SalesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public SalesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates a new sale
        /// </summary>
        /// <param name="model">Sales model</param>
        /// <returns>Unit</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<Unit> Create([FromBody] SaleModel model)
        {
            var command = _mapper.Map<CreateSaleCommandHandler.Command>(model);
            return await _mediator.Send(command);
        }

    }
}
