using Domain.Ports.Repositories;
using Infraestructure.Persistance.Repositories._Common;
using MediatR;
using Sat.Recruitment.Application.Common.Interfaces;
using Sat.Recruitment.Domain.Entities;
using Sat.Recruitment.Infrastructure.Persistence;

namespace Infraestructure.Persistance.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context, IMediator mediator, IDateTime dateTime) : base(context, mediator, dateTime)
        {
        }
    }
}
