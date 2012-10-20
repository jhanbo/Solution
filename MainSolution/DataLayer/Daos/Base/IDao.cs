using System.Collections.Generic;

namespace ITGateWorkDesk.Data.DAO.Base
{
    public interface IDao<TEntity, TId>
    {
        TId Create(TEntity entity); // return type has been changed to TID 
        void Update(TEntity entity);
        void Delete(TEntity entity);
        TEntity GetByID(TId id);
        IList<TEntity> GetAll();
        IList<TEntity> GetPaginatedList(int currentPageIndex, int pageSize);
    }
}