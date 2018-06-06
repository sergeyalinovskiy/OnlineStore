namespace SA.OnlineStore.DataAccess.Service
{
    #region Usings
    using SA.OnlineStore.Common.Entity;
    using System.Collections.Generic;
    #endregion

    public interface ISeasonRepository
    {
        List<Season> GetSeasonList();
    }
}
