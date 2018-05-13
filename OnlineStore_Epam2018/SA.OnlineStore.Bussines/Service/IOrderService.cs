namespace SA.OnlineStore.Bussines.Service
{
    #region Usings
    using SA.OnlineStore.Common.Entity;
    using System.Collections.Generic;
    #endregion
    public interface IOrderService
    {
        void DeleteOrderByOrderId(int Id);
        void SaveOrder(OrderModel model);
        void EditOrder(OrderModel model);
        OrderModel GetOrder(int Id);
        IEnumerable<OrderModel> GetOrderList();
    }
}