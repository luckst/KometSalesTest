using AutoMapper;
using KometSales.Common.Entities.Dtos;
using KometSales.Ifrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KometSales.Application.Customers.Queries
{
    public class SearchCustomersQueryHandler
    {
        public class Query : IRequest<List<CustomerDto>>
        {
            public string Filter { get; set; }
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
                var customers = await _context.Customers.Where(p => p.Active &&
                (string.IsNullOrEmpty(query.Filter) || p.FirstName.Contains(query.Filter) || p.LastName.Contains(query.Filter))).ToListAsync();

                return _mapper.Map<List<CustomerDto>>(customers);
            }
        }
    }
}

