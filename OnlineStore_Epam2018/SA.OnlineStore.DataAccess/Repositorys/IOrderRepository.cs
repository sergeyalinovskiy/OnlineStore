namespace SA.OnlineStore.DataAccess.Repositorys
{
    #region Usings
        using SA.OnlineStore.Common.Entity;
        using SA.OnlineStore.DataAccess.Implements;
        using System.Collections.Generic;
    #endregion
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<StatusOrder> GetStatusOrder();
        void SaveDefaultOrder(int userId);
    }
}