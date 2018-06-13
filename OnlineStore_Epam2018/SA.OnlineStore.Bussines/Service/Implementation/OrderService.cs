namespace SA.OnlineStore.Bussines.Components
{
    #region Usings
    using SA.OnlineStore.Bussines.Service;
    using SA.OnlineStore.Common.Entity;
    using SA.OnlineStore.DataAccess.Implements;
    using SA.OnlineStore.DataAccess.Service;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    #endregion

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void DeleteOrderByOrderId(int Id)
        {
            if (Id > 0)
            {
                _orderRepository.Delete(Id);
            }
        }

        public Order GetOrder(int Id)
        {
            if (Id < 1)
            {
                return null;
            }
            return _orderRepository.GetAll().Where(t => t.Id == Id).FirstOrDefault();
        }

        public IEnumerable<Order> GetOrderList()
        {
            return _orderRepository.GetAll();
        }

        public void SaveOrder(Order model)
        {
            if (model != null)
            {
                _orderRepository.Create(model);
            }
        }

        public void SaveDefaultOrder(int id)
        {
            if (id > 0)
            {
                _orderRepository.SaveDefaultOrder(id);
            }
        }

        public void EditOrder(Order model)
        {
            if (model != null)
            {
                _orderRepository.Update(model);
            }
        }

        public IEnumerable<StatusOrder> GetStatusOrders()
        {
            var orderStatus = _orderRepository.GetStatusOrder();
            return orderStatus;
        }
    }
}
