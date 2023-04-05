using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sat.Recruitment.Application.Common.Interfaces;
using Sat.Recruitment.Application.CQRS.Users.Queries.GetUserById;
using Sat.Recruitment.Domain.Common;
using Sat.Recruitment.Domain.Ports.Repositories._Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Persistance.Repositories._Common;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{
    protected DbContext _context;
    protected DbSet<TEntity> _entities;
    private readonly IMediator _mediator;
    private readonly IDateTime _dateTime;

    public Repository(DbContext context, IMediator mediator, IDateTime dateTime)
    {
        _context = context;
        _entities = _context.Set<TEntity>();
        _mediator = mediator;
        _dateTime = dateTime;
    }

    public void Add(TEntity entity)
    {
        _entities.Add(entity);
    }

    public void Update(TEntity entity)
    {
        _entities.Update(entity);
    }

    public void UpdateRange(List<TEntity> entity)
    {
        _entities.UpdateRange(entity);
    }

    public void Delete(TEntity entity)
    {
        _entities.Remove(entity);
    }

    public async Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate, bool ignoreQueryFilters = false)
    {
        if (ignoreQueryFilters)
            return await _entities.AsNoTracking().IgnoreQueryFilters().FirstOrDefaultAsync(predicate);

        return await _entities.AsNoTracking().FirstOrDefaultAsync(predicate);
    }

    public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate, bool ignoreQueryFilters = false)
    {
        return await _entities.Where(predicate).ToListAsync();
    }

    public async Task<int> Save(CancellationToken cancellationToken)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}
