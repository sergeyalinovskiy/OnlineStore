
using SA.OnlineStore.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.OnlineStore.Bussines.Service
{
    public interface IOrderService
    {
        void DeleteOrderByOrderId(int Id);
        void SaveOrder(OrderModel model);
        void EditOrder(OrderModel model);
        OrderModel GetOrder(int Id);
        IEnumerable<OrderModel> GetOrderList();
    }
}
