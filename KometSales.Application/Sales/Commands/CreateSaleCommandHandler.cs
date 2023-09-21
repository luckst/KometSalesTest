using AutoMapper;
using KometSales.Common.Entities.Models;
using KometSales.Domain;
using KometSales.Ifrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KometSales.Application.Sales.Commands
{
    public class CreateSaleCommandHandler
    {
        public class Command : SaleModel, IRequest<Unit>
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
                if (command.SaleDetails == null || command.SaleDetails.Count == 0)
                {
                    throw new ArgumentNullException("Products are required");
                }

                var sale = await GetSale(command);

                // Create an instance of the execution strategy
                var executionStrategy = _context.Database.CreateExecutionStrategy();

                // Use the execution strategy to execute the transaction
                await executionStrategy.Execute(async () =>
                {
                    using (var tran = await _context.Database.BeginTransactionAsync())
                    {
                        try
                        {
                            _context.Sales.Add(sale);
                            await _context.SaveChangesAsync();

                            List<Product> updatedProducts = await GetUpdatedProducts(sale);

                            _context.Products.UpdateRange(updatedProducts);
                            _context.SaveChanges();

                            await tran.CommitAsync();
                        }
                        catch (Exception)
                        {
                            await tran.RollbackAsync();
                            throw;
                        }
                    }
                });

                return new Unit();
            }

            private async Task<Sale> GetSale(Command command)
            {
                var sale = _mapper.Map<Sale>(command);
                sale.Id = Guid.NewGuid();
                sale.SaleDate = DateTime.Now;
                sale.SaleDetails = new List<SaleDetail>();
                sale.TotalAmount = 0;

                foreach (var detail in command.SaleDetails)
                {
                    var saleDetail = _mapper.Map<SaleDetail>(detail);
                    var product = await _context.Products.FindAsync(saleDetail.ProductId);
                    saleDetail.TotalPrice = saleDetail.Quantity * product.Price;
                    sale.SaleDetails.Add(saleDetail);
                }

                sale.TotalAmount = sale.SaleDetails.Sum(d => d.TotalPrice);

                return sale;
            }

            private async Task<List<Product>> GetUpdatedProducts(Sale sale)
            {
                var updatedProducts = new List<Product>();

                foreach (var detail in sale.SaleDetails)
                {
                    var product = await _context.Products.FindAsync(detail.ProductId);

                    product!.Quantity -= detail.Quantity;

                    updatedProducts.Add(product);
                }

                return updatedProducts;
            }
        }
    }
}
