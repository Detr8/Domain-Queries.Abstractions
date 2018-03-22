using System;
using System.Collections.Generic;
using System.Text;

namespace DomainQueries.Abstracts.ReadModel
{
    public abstract class BaseReadModel<TID> where TID:struct
    {
        public TID Id { get; set; }
    }
}
