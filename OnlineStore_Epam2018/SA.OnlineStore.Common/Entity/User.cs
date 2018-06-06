namespace SA.OnlineStore.Common.Entity
{
    public class User
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public Role Role { get; set; }
        public Phone Phone { get; set; }
        public Email Email { get; set; }
    }
}