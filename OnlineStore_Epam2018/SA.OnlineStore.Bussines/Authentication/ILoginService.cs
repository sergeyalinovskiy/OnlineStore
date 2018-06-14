namespace SA.OnlineStore.Bussines.Authentication
{
    public interface ILoginService
    {
        bool Login(string login, string password);
        void Logout();
    }
}