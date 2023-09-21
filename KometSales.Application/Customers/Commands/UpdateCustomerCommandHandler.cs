using KometSales.Common.Entities.Models;
using KometSales.Ifrastructure;
using MediatR;

namespace KometSales.Application.Customers.Commands
{
    public class UpdateCustomerCommandHandler
    {
        public class Command : CustomerModel, IRequest<Unit>
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

                customer.FirstName = command.FirstName;
                customer.LastName = command.LastName;
                customer.Phone = command.Phone;
                customer.Email = command.Email;
                customer.Address = command.Address;

                _context.Customers.Update(customer);
                await _context.SaveChangesAsync();

                return new Unit();
            }
        }
    }
}
