using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NHibernate.Linq;
using Spring.Data.NHibernate.Generic.Support;
using Spring.Transaction.Interceptor;

namespace ITGateWorkDesk.Data.DAO.Base
{
    public abstract class DaoBase<TEntity, TId> : HibernateDaoSupport, IDao<TEntity, TId>
    {
        [Transaction(ReadOnly = false)]
        public virtual TId Create(TEntity entity)
        {
            return (TId)HibernateTemplate.Save(entity);
        }
        [Transaction(ReadOnly = false)]
        public virtual void Update(TEntity entity)
        {
            HibernateTemplate.SaveOrUpdate(entity);
        }
        [Transaction(ReadOnly = false)]
        public virtual void Delete(TEntity entity)
        {
            HibernateTemplate.Delete(entity);
        }
        [Transaction(ReadOnly = true)]
        public virtual TEntity GetByID(TId id)
        {
            return HibernateTemplate.Load<TEntity>(id);
        }
        [Transaction(ReadOnly = true)]
        public virtual IList<TEntity> GetAll()
        {
            return HibernateTemplate.LoadAll<TEntity>();
        }

        [Transaction(ReadOnly = true)]
        public virtual IList<TEntity> GetPaginatedList(int currentPageIndex, int pageSize)
        {
            return new List<TEntity>();
        }

        public virtual int Count<TEntity>(Expression<Func<TEntity, bool>> where)
        {
            return HibernateTemplate.SessionFactory
                .GetCurrentSession()
                .Query<TEntity>()
                .Where(where)
                .Count();

        }
    }
}
