using System;

namespace SA.OnlineStore.Common.Entity
{
    public class OrderModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Address { get; set; }
        public int StatusId { get; set; }
        public DateTime DateOrder { get; set; }
    }
}
