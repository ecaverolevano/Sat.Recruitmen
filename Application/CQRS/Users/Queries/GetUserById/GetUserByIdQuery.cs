using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Ports.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sat.Recruitment.Application.Common.Interfaces;
using Sat.Recruitment.Domain.Entities;
using Sat.Recruitment.Domain.Ports.Repositories._Common;

namespace Sat.Recruitment.Application.CQRS.Users.Queries.GetUserById;

public class GetUserByIdQuery : IRequest<GetUserByIdDto>
{
    public GetUserByIdQuery(int userId)
    {
        UserId = userId;
    }

    public int UserId { get; }
}

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdDto>
{
    //private readonly IApplicationDbContext _context;
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;

    //public GetUserByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    //{
    public GetUserByIdQueryHandler(IUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetUserByIdDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _repository.Get(x => x.Id == request.UserId);
        var userSumary = _mapper.Map<UserSummary>(user);
        //.ProjectTo<UserSummary>(_mapper.ConfigurationProvider)
        //.FirstOrDefaultAsync(x => x.Id == request.UserId);

        return new GetUserByIdDto()
        {
            User = userSumary
        };
    }
}
