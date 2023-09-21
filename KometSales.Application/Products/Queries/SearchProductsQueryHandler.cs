using AutoMapper;
using KometSales.Common.Entities.Dtos;
using KometSales.Ifrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KometSales.Application.Products.Queries
{
    public class SearchProductsQueryHandler
    {
        public class Query : IRequest<List<ProductDto>>
        {
            public string Filter { get; set; }
        }

        public class Handler : IRequestHandler<Query, List<ProductDto>>
        {
            private readonly ServiceDbContext _context;
            private readonly IMapper _mapper;

            public Handler(ServiceDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<ProductDto>> Handle(
                Query query,
                CancellationToken cancellationToken
            )
            {
                var products = await _context.Products.Where(p => p.Active &&
                (string.IsNullOrEmpty(query.Filter) || p.ProductName.Contains(query.Filter))).ToListAsync();

                return _mapper.Map<List<ProductDto>>(products);
            }
        }
    }
}

