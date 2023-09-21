using KometSales.Common.Entities.Models;
using KometSales.Ifrastructure;
using MediatR;

namespace KometSales.Application.Products.Commands
{
    public class UpdateProductCommandHandler
    {
        public class Command : ProductModel, IRequest<Unit>
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

                if (product == null)
                {
                    throw new NullReferenceException("Product not found");
                }

                product.ProductName = command.ProductName;
                product.Price = command.Price;
                product.Quantity = command.Quantity;
                product.Description = command.Description;

                _context.Products.Update(product);
                await _context.SaveChangesAsync();

                return new Unit();
            }
        }
    }
}
