using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.OnlineStore.Bussines.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductListId { get; set; }
        public string Address { get; set; }
        public int StatusId { get; set; }
        public DateTime DateOrder { get; set; }
    }
}
