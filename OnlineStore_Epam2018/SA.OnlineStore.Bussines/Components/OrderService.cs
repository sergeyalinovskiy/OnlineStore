
using SA.OnlineStore.Bussines.Service;
using SA.OnlineStore.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.OnlineStore.Bussines.Components
{
    public class OrderService : IOrderService
    {
        private List<OrderModel> _orders = new List<OrderModel>() {
            new OrderModel() {Id=1,
                         UserId =1,
                         StatusId=1,
                         Address="qe",
                         DateOrder=DateTime.Now.Date
            } ,
            new OrderModel() {Id=1,
                         UserId =2,
                         StatusId=1,
                         Address="qe",
                         DateOrder=DateTime.Now.Date
            } ,
            new OrderModel() {Id=1,
                         UserId =3,
                         StatusId=1,
                         Address="qe",
                         DateOrder=DateTime.Now.Date
            }};

        public void DeleteOrderByOrderId(int Id)
        {
            _orders.RemoveAt(Id);
        }

        public OrderModel GetOrder(int Id)
        {
            return _orders.Where(t => t.Id == Id).FirstOrDefault();
        }

        public IEnumerable<OrderModel> GetOrderList()
        {
            return _orders;
        }

        public void SaveOrder(OrderModel model)
        {
            _orders.Add(new OrderModel
            {
                Id = model.Id,
                UserId=model.UserId,
                StatusId=model.StatusId,
                Address=model.Address,
                DateOrder=model.DateOrder
            });
        }

        public void EditOrder(OrderModel model)
        {
            _orders[model.Id].StatusId = model.StatusId;
            _orders[model.Id].Address = model.Address;
            _orders[model.Id].DateOrder = model.DateOrder;
            _orders[model.Id].UserId = model.UserId;
        }
    }
}
