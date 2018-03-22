using DomainQueries.Abstracts.ReadModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainQueries.Abstracts.Queries
{
    public interface IBaseQueries<TEntity, TID> where TEntity : BaseReadModel<TID> where TID: struct
    {
        ICollection<TEntity> GetAll();
        TEntity GetById(TID id);

        ICollection<TEntity> GetList(FilterModel<TEntity> filter, bool withPaging=true);
        int GetCount(FilterModel<TEntity> filter);

        GridResult<TEntity> GetGridPresentation(FilterModel<TEntity> filter);
    }
}
