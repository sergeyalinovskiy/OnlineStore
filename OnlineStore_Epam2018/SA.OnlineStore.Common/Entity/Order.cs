namespace SA.OnlineStore.Common.Entity
{
    #region Usings
    using System;
    #endregion
    public class Order
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string Address { get; set; }
        public StatusOrder StatusOrder { get; set; }
        public DateTime DateOrder { get; set; }
    }
}
