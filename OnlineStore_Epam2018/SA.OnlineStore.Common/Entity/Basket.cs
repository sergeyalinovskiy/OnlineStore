namespace SA.OnlineStore.Common.Entity
{
   public class Basket
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public string Picture { get; set; }
    }
}
