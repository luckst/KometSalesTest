using KometSales.Ifrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KometSales.Application.Users.Commands
{
    public class ValidateUserCommandHandler
    {
        public class Command : IRequest<(bool, string)>
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }

        public class Handler : IRequestHandler<Command, (bool, string)>
        {
            private readonly ServiceDbContext _context;

            public Handler(ServiceDbContext context)
            {
                _context = context;
            }

            public async Task<(bool, string)> Handle(
                Command command,
                CancellationToken cancellationToken
            )
            {
                if (string.IsNullOrWhiteSpace(command.UserName) || string.IsNullOrWhiteSpace(command.Password))
                {
                    throw new ArgumentNullException("Username and password are required");
                }

                var user = await _context.Users.Include(u => u.UserRol).FirstOrDefaultAsync(u => u.UserName.ToLower() == command.UserName.ToLower() && u.Active);

                if (user == null) { return (false, string.Empty); }

                if (user.Password != command.Password) { return (false, string.Empty); }

                return (true, user.UserRol.RoleName);
            }
        }
    }
}
