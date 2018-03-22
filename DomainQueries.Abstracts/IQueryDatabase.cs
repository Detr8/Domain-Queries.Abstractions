using DomainQueries.Abstracts.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainQueries.Abstracts
{
    public interface IQueryDatabase
    {
        IQueryable<TEntity> GetQueryableForEntities<TEntity, TID>(bool noTracking=true, bool onlyExisting=true) where TEntity : BaseReadModel<TID>;
        
        
    }
}
