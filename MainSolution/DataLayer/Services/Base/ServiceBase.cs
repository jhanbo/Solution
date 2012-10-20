using System.Collections.Generic;
using ITGateWorkDesk.Data.DAO.Base;

namespace ITGateWorkDesk.Data.Services.Base
{
    public class ServiceBase<TDao, TEntity, TId> : IService<TDao, TEntity, TId> where TDao : IDao<TEntity, TId>
    {
        private TDao _dao;
        public TDao Dao
        {
            get { return _dao; }
            set { _dao = value; }
        }

        public virtual IList<TEntity> GetAll()
        {
            return this._dao.GetAll();
        }

        public virtual TEntity GetByID(TId id)
        {
            return this._dao.GetByID(id);
        }
        public virtual TId Create(TEntity entity) // return type has been changed to TID 
        {
            return this._dao.Create(entity);
        }
        public virtual void Update(TEntity entity)
        {
            _dao.Update(entity);
        }
        public virtual void Delete(TEntity entity)
        {
            this._dao.Delete(entity);
        }
        public virtual IList<TEntity> GetPagedList(int pageIndex, int pageSize)
        {
            return this._dao.GetPaginatedList(pageIndex, pageSize);
        }

    }
}