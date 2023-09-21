using AutoMapper;
using KometSales.Common.Entities.Dtos;
using KometSales.Ifrastructure;
using MediatR;

namespace KometSales.Application.Customers.Queries
{
    public class GetCustomerQueryHandler
    {
        public class Query : IRequest<CustomerDto>
        {
            public Guid CustomerId { get; set; }
        }

        public class Handler : IRequestHandler<Query, CustomerDto>
        {
            private readonly ServiceDbContext _context;
            private readonly IMapper _mapper;

            public Handler(ServiceDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<CustomerDto> Handle(
                Query query,
                CancellationToken cancellationToken
            )
            {
                return _mapper.Map<CustomerDto>(await _context.Customers.FindAsync(query.CustomerId));
            }
        }
    }
}

