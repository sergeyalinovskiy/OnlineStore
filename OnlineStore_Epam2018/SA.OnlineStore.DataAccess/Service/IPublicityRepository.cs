namespace SA.OnlineStore.DataAccess.Service
{
    #region Usings
    using SA.OnlineStore.Common.Entity;
    using System.Collections.Generic;
    #endregion

    public interface IPublicityRepository
    {
        //PublicityModel GetPublicity();
        IEnumerable<PublicityModel> GetDefaultList();
        IEnumerable<PublicityModel> GetPublicityList();
    }
}
