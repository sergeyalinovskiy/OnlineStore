namespace SA.OnlineStore.Common.Entity
{
    public class Login
    {
        public int id { get; set; }    
        public string userLogin { get; set; }
        public string passsword { get; set; }
        public Role[] role { get; set; }
    }
}