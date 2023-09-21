using AutoMapper;
using KometSales.Common.Entities.Models;
using KometSales.Domain;
using KometSales.Ifrastructure;
using MediatR;

namespace KometSales.Application.Products.Commands
{
    public class CreateProductCommandHandler
    {
        public class Command : CreateProductModel, IRequest<Unit>
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
                var product = _mapper.Map<Product>(command);
                product.Id = Guid.NewGuid();
                product.Active = true;

                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();

                return new Unit();
            }
        }
    }
}
