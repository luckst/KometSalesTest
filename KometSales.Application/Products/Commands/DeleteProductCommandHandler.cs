using KometSales.Ifrastructure;
using MediatR;

namespace KometSales.Application.Products.Commands
{
    public class DeleteProductCommandHandler
    {
        public class Command : IRequest<Unit>
        {
            public Guid ProductId { get; set; }
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
                var product = await _context.Products.FindAsync(command.ProductId);
                product.Active = false;

                _context.Products.Update(product);
                await _context.SaveChangesAsync();

                return new Unit();
            }
        }
    }
}
