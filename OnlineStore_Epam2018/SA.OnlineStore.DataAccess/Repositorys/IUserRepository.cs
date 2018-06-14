namespace SA.OnlineStore.DataAccess.Repositorys
{
    #region Usings
        using SA.OnlineStore.Common.Entity;
        using SA.OnlineStore.DataAccess.Implements;
    #endregion
    public interface IUserRepository : IRepository<User>
    {
        User GetByLogin(string login);
    }
}