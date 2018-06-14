namespace SA.OnlineStore.Bussines.Service
{
    #region Usings
        using SA.OnlineStore.Common.Entity;
        using System.Collections.Generic;
    #endregion
    public interface IUserService
    {
        User GetUserById(int id);

        void DeleteUserByUserId(int id);

        IEnumerable<User> GetUsersList();

        void SaveUser(User model);

        User GetUserByLogin(string login);
    }
}