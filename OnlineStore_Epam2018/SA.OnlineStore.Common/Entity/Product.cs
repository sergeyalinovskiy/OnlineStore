namespace SA.OnlineStore.Common.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public Season Season{ get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
    }
}
