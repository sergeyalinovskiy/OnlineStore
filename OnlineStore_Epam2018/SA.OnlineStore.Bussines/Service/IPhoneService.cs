namespace SA.OnlineStore.Bussines.Service
{
    #region Usings
        using SA.OnlineStore.Common.Entity;
        using System.Collections.Generic;
    #endregion
    public interface IPhoneService
    {
        IEnumerable<Phone> GetPhnesByUserId(int id);
        IEnumerable<Phone> GetPhoneList();
    }
}