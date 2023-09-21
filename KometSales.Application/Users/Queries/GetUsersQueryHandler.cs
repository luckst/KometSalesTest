using AutoMapper;
using KometSales.Common.Entities.Dtos;
using KometSales.Ifrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KometSales.Application.Users.Queries
{
    public class GetUsersQueryHandler
    {
        public class Query : IRequest<List<UserDto>>
        {
        }

        public class Handler : IRequestHandler<Query, List<UserDto>>
        {
            private readonly ServiceDbContext _context;
            private readonly IMapper _mapper;

            public Handler(ServiceDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<UserDto>> Handle(
                Query query,
                CancellationToken cancellationToken
            )
            {
                return _mapper.Map<List<UserDto>>(await _context.Users.Include(u => u.UserRol).Where(c => c.Active).ToListAsync());
            }
        }
    }
}

