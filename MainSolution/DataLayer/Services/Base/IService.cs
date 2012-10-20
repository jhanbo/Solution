using ITGateWorkDesk.Data.DAO.Base;

namespace ITGateWorkDesk.Data.Services.Base
{
    public interface IService<TDao, TEntity, TId> where TDao : IDao<TEntity, TId>
    {
       
    }
}
