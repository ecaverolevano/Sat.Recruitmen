using Sat.Recruitment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Sat.Recruitment.Application.Common.Interfaces;
public interface IApplicationDbContext
{
    DbSet<User> Users{ get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
