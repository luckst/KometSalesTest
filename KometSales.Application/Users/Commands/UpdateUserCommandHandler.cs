﻿using KometSales.Common.Entities.Models;
using KometSales.Domain;
using KometSales.Ifrastructure;
using MediatR;

namespace KometSales.Application.Users.Commands
{
    public class UpdateUserCommandHandler
    {
        public class Command : UpdateUserModel, IRequest<Unit>
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

                if (user == null)
                {
                    throw new NullReferenceException("User not found");
                }

                user.UserName = command.UserName;
                user.RoleId = command.RoleId;
                user.Email = command.Email;

                _context.Users.Update(user);
                await _context.SaveChangesAsync();

                return new Unit();
            }
        }
    }
}
