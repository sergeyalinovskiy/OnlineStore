namespace SA.OnlineStore.Bussines.Components
{
    #region Usings
    using SA.OnlineStore.Bussines.Service;
    using SA.OnlineStore.Common.Entity;
    using SA.OnlineStore.DataAccess.Implements;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    #endregion

    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        
        public OrderService(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }
        //private List<Order> _orders = new List<Order>() {
        //    new Order() {Id=1,
        //                 UserId =1,
        //                 StatusId=1,
        //                 Address="qe",
        //                 DateOrder=DateTime.Now.Date
        //    } ,
        //    new Order() {Id=1,
        //                 UserId =2,
        //                 StatusId=1,
        //                 Address="qe",
        //                 DateOrder=DateTime.Now.Date
        //    } ,
        //    new Order() {Id=1,
        //                 UserId =3,
        //                 StatusId=1,
        //                 Address="qe",
        //                 DateOrder=DateTime.Now.Date
        //    }};

        public void DeleteOrderByOrderId(int Id)
        {
            _orderRepository.Delete(Id);
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

        public void GetDefaultOrder(int id)
        {
            if (id > 0)
            {
                Order order = new Order
                {
                    DateOrder = DateTime.Now,
                    User = new User() { UserId = id },
                    StatusOrder = new StatusOrder() { Id = 1 },
                    Address = "куда вести?"
                };
                _orderRepository.Create(order);
            }
        }

        public void EditOrder(Order model)
        {
            if (model != null)
            {
                _orderRepository.Update(model);
            }
        }
    }
}
