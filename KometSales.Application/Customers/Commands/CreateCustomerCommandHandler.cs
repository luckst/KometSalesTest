using AutoMapper;
using KometSales.Common.Entities.Models;
using KometSales.Domain;
using KometSales.Ifrastructure;
using MediatR;

namespace KometSales.Application.Customers.Commands
{
    public class CreateCustomerCommandHandler
    {
        public class Command : CustomerModel, IRequest<Unit>
        {
        }

        public class Handler : IRequestHandler<Command, Unit>
        {
            private readonly ServiceDbContext _context;
            private readonly IMapper _mapper;

            public Handler(ServiceDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(
                Command command,
                CancellationToken cancellationToken
            )
            {
                var customer = _mapper.Map<Customer>(command);
                customer.Id = Guid.NewGuid();
                customer.Active = true;

                await _context.Customers.AddAsync(customer);
                await _context.SaveChangesAsync();

                return new Unit();
            }
        }
    }
}
