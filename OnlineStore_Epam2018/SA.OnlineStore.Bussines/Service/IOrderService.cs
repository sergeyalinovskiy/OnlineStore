namespace SA.OnlineStore.Bussines.Service
{
    #region Usings
    using SA.OnlineStore.Common.Entity;
    using System.Collections.Generic;
    #endregion
    public interface IOrderService
    {
        void DeleteOrderByOrderId(int Id);
        void SaveOrder(Order model);
        void EditOrder(Order model);
        Order GetOrder(int Id);
        IEnumerable<Order> GetOrderList();
        void SaveDefaultOrder(int UserId);
        IEnumerable<StatusOrder> GetStatusOrders();
        
    }
}