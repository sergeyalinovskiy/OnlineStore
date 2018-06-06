namespace SA.OnlineStore.Bussines.Service
{
    #region Usings
    using SA.OnlineStore.Common.Entity;
    using System.Collections.Generic;
    #endregion

    public interface IPublicityService
    {
        //PublicityModel GetPublicity();
        IEnumerable<Publicity> GetDefaultList();
        IEnumerable<Publicity> GetPublicityList();
    }
}
