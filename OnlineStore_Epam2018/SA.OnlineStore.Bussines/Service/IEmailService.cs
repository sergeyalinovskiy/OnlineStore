namespace SA.OnlineStore.Bussines.Service
{
    #region Usings
        using SA.OnlineStore.Common.Entity;
        using System.Collections.Generic;
    #endregion
    public interface IEmailService
    {
        IEnumerable<Email> GetEmailsByUserId(int id);
        IEnumerable<Email> GetEmailList();
    }
}
