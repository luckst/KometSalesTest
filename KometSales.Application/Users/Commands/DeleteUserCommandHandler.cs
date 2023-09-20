using KometSales.Common.Entities.Models;
using KometSales.Ifrastructure;
using MediatR;

namespace KometSales.Application.Users.Commands
{
    public class DeleteUserCommandHandler
    {
        public class Command : IRequest<Unit>
        {
            public Guid UserId { get; set; }
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
                var user = await _context.Users.FindAsync(command.UserId);
                user.Active = false;

                _context.Users.Update(user);
                await _context.SaveChangesAsync();

                return new Unit();
            }
        }
    }
}
