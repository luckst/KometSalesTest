using AutoMapper;
using KometSales.Common.Entities.Dtos;
using KometSales.Ifrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KometSales.Application.Products.Queries
{
    public class GetProductsQueryHandler
    {
        public class Query : IRequest<List<ProductDto>>
        {
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
                return _mapper.Map<List<ProductDto>>(await _context.Products.ToListAsync());
            }
        }
    }
}

