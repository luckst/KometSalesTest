using AutoMapper;
using KometSales.Common.Entities.Dtos;
using KometSales.Ifrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KometSales.Application.Customers.Queries
{
    public class GetCustomersQueryHandler
    {
        public class Query : IRequest<List<CustomerDto>>
        {
        }

        public class Handler : IRequestHandler<Query, List<CustomerDto>>
        {
            private readonly ServiceDbContext _context;
            private readonly IMapper _mapper;

            public Handler(ServiceDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<CustomerDto>> Handle(
                Query query,
                CancellationToken cancellationToken
            )
            {
                return _mapper.Map<List<CustomerDto>>(await _context.Customers.Where(c => c.Active).ToListAsync());
            }
        }
    }
}

