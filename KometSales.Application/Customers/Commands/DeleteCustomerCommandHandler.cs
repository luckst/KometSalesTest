using KometSales.Domain;
using KometSales.Ifrastructure;
using MediatR;

namespace KometSales.Application.Customers.Commands
{
    public class DeleteCustomerCommandHandler
    {
        public class Command : IRequest<Unit>
        {
            public Guid CustomerId { get; set; }
        }

        public class Handler : IRequestHandler<Command, Unit>
        {
            private readonly ServiceDbContext _context;

            public Handler(ServiceDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(
                Command command,
                CancellationToken cancellationToken
            )
            {
                var customer = await _context.Customers.FindAsync(command.CustomerId);

                if (customer == null)
                {
                    throw new NullReferenceException("Customer not found");
                }

                customer.Active = false;

                _context.Customers.Update(customer);
                await _context.SaveChangesAsync();

                return new Unit();
            }
        }
    }
}
