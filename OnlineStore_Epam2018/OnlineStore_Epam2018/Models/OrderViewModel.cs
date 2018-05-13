namespace OnlineStore_Epam2018.Models
{
    #region Usings
    using System;
    #endregion

    public class OrderViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductListId { get; set; }
        public string Address { get; set; }
        public int StatusId { get; set; }
        public DateTime DateOrder { get; set; }
    }
}