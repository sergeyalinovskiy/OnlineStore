using SA.OnlineStore.Bussines.Entity;
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
        void SaveOrder(Order model);
        void EditOrder(Order model);
        Order GetOrder(int Id);
        IEnumerable<Order> GetOrderList();
    }
}
