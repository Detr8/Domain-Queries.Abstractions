using DomainQueries.Abstracts.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainQueries.Abstracts.Queries
{
    public class BaseQueries<TEntity, TID> : IBaseQueries<TEntity, TID> where TEntity: BaseReadModel<TID> where TID:struct, IEquatable<TID>
    {
        protected readonly IQueryDatabase db;

        public BaseQueries(IQueryDatabase db)
        {
            this.db = db;
        }
        

        protected virtual IQueryable<TEntity> Queryable => db.GetQueryableForEntities<TEntity, TID>();

        public ICollection<TEntity> GetAll()
        {
            return Queryable.ToList();
        }

        public TEntity GetById(TID id)
        {
            return Queryable.FirstOrDefault(x => x.Id.Equals(id));
        }

        public int GetCount(FilterModel<TEntity> filter)
        {
            return Queryable.ApplyFilter(filter).Count();
        }

        public virtual ICollection<TEntity> GetList(FilterModel<TEntity> filter, bool withPaging=true)
        {
            var query = Queryable
                .ApplyFilter(filter)
                .ApplySorting(filter);

            if (withPaging)
                query = query.ApplyPaging(filter);

            return query.ToList();
                
        }

        protected virtual IQueryable<TEntity> ApplyFilterToQuery(IQueryable<TEntity> queryable, FilterModel<TEntity> filter, bool withPaging=true)
        {
            var query = queryable
                .ApplyFilter(filter)
                .ApplySorting(filter);

            if(withPaging)
                query=query.ApplyPaging(filter);

            return query;
        }

        public virtual GridResult<TEntity> GetGridPresentation(FilterModel<TEntity> filter)
        {
            var result = new GridResult<TEntity>();

            result.ItemsNumber = GetCount(filter);
            result.Items = GetList(filter);
            result.CurrentFilter = filter;

            return result;
        }
    }
}
