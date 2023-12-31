﻿using AutoMapper;
using KometSales.Application.Products.Commands;
using KometSales.Application.Products.Queries;
using KometSales.Common.Entities.Dtos;
using KometSales.Common.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KometSales.Api.Controllers
{
    /// <summary>
    /// products controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets products list
        /// </summary>
        /// <returns>List of products</returns>
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(typeof(List<ProductDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<List<ProductDto>> Get()
        {
            return await _mediator.Send(new GetProductsQueryHandler.Query());
        }

        /// <summary>
        /// Gets product
        /// </summary>
        /// <param name="productId">Product identifier</param>
        /// <returns>Product</returns>
        [HttpGet("{productId}")]
        [Authorize(Roles = "Administrator,Sales")]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ProductDto> GetProduct([FromRoute] Guid productId)
        {
            return await _mediator.Send(new GetProductQueryHandler.Query() { ProductId = productId });
        }

        /// <summary>
        /// Search for products
        /// </summary>
        /// <param name="filter">Filter</param>
        /// <returns>List of products</returns>
        [Authorize(Roles = "Administrator,Sales")]
        [HttpGet("search")]
        [ProducesResponseType(typeof(List<ProductDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<List<ProductDto>> Search(string? filter)
        {
            return await _mediator.Send(new SearchProductsQueryHandler.Query() { Filter = filter });
        }

        /// <summary>
        /// Creates a new product
        /// </summary>
        /// <param name="model">Create product model</param>
        /// <returns>Unit</returns>
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<Unit> Create([FromBody] ProductModel model)
        {
            var command = _mapper.Map<CreateProductCommandHandler.Command>(model);
            return await _mediator.Send(command);
        }

        /// <summary>
        /// Updates a product
        /// </summary>
        /// <param name="model">Update product model</param>
        /// <returns>Unit</returns>
        [HttpPut("{productId}")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<Unit> Update([FromRoute] Guid productId, [FromBody] ProductModel model)
        {
            var command = _mapper.Map<UpdateProductCommandHandler.Command>(model);
            command.ProductId = productId;
            return await _mediator.Send(command);
        }

        /// <summary>
        /// Deletes a product
        /// </summary>
        /// <param name="productId">product identifier</param>
        /// <returns>Unit</returns>
        [HttpDelete("{productId}")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<Unit> Delete([FromRoute] Guid productId)
        {
            var command = new DeleteProductCommandHandler.Command()
            {
                ProductId = productId
            };
            return await _mediator.Send(command);
        }
    }
}
