using SA.OnlineStore.Common.Entity;
using SA.OnlineStore.DataAccess.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.OnlineStore.DataAccess.Service
{
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<StatusOrder> GetStatusOrder();
        void SaveDefaultOrder(int userId);
    }
}
