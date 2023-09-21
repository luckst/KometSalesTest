using AutoMapper;
using KometSales.Common.Entities.Dtos;
using KometSales.Ifrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KometSales.Application.UserRoles.Queries
{
    public class GetUserRolesQueryHandler
    {
        public class Query : IRequest<List<UserRolDto>>
        {
        }

        public class Handler : IRequestHandler<Query, List<UserRolDto>>
        {
            private readonly ServiceDbContext _context;
            private readonly IMapper _mapper;

            public Handler(ServiceDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<UserRolDto>> Handle(
                Query query,
                CancellationToken cancellationToken
            )
            {
                return _mapper.Map<List<UserRolDto>>(await _context.UserRoles.ToListAsync());
            }
        }
    }
}
