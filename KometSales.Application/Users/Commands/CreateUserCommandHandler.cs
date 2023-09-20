using AutoMapper;
using KometSales.Common.Entities.Models;
using KometSales.Domain;
using KometSales.Ifrastructure;
using MediatR;

namespace KometSales.Application.Users.Commands
{
    public class CreateUserCommandHandler
    {
        public class Command : CreateUserModel, IRequest<Unit>
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
                if (string.IsNullOrWhiteSpace(command.UserName) || string.IsNullOrWhiteSpace(command.Password))
                {
                    throw new ArgumentNullException("Username and password are required");
                }

                var user = _mapper.Map<User>(command);
                user.Id = Guid.NewGuid();
                user.Active = true;

                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();

                return new Unit();
            }
        }
    }
}
