namespace SA.OnlineStore.Common.Entity
{
   public class Basket
    {
        public int Id { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
        public Category Category { get; set; }
    }
}