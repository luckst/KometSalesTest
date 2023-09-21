using AutoMapper;
using KometSales.Common.Entities.Dtos;
using KometSales.Ifrastructure;
using MediatR;

namespace KometSales.Application.Products.Queries
{
    public class GetProductQueryHandler
    {
        public class Query : IRequest<ProductDto>
        {
            public Guid UserId { get; set; }
        }

        public class Handler : IRequestHandler<Query, ProductDto>
        {
            private readonly ServiceDbContext _context;
            private readonly IMapper _mapper;

            public Handler(ServiceDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ProductDto> Handle(
                Query query,
                CancellationToken cancellationToken
            )
            {
                return _mapper.Map<ProductDto>(await _context.Products.FindAsync(query.UserId));
            }
        }
    }
}

