using Sat.Recruitment.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Domain.Ports.Repositories._Common;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    void Add(TEntity entity);
    void Update(TEntity entity);
    void UpdateRange(List<TEntity> entity);
    void Delete(TEntity entity);
    Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate, bool ignoreQueryFilters = false);
    Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate, bool ignoreQueryFilters = false);
    Task<int> Save(CancellationToken cancellationToken);
}
