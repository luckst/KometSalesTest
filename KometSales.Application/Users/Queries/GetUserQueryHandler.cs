using AutoMapper;
using KometSales.Common.Entities.Dtos;
using KometSales.Ifrastructure;
using MediatR;

namespace KometSales.Application.Users.Queries
{
    public class GetUserQueryHandler
    {
        public class Query : IRequest<UserDto>
        {
            public Guid UserId { get; set; }
        }

        public class Handler : IRequestHandler<Query, UserDto>
        {
            private readonly ServiceDbContext _context;
            private readonly IMapper _mapper;

            public Handler(ServiceDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<UserDto> Handle(
                Query query,
                CancellationToken cancellationToken
            )
            {
                return _mapper.Map<UserDto>(await _context.Users.FindAsync(query.UserId));
            }
        }
    }
}

