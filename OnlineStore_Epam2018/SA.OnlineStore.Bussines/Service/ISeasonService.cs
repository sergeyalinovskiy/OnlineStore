namespace SA.OnlineStore.Bussines.Service
{
    #region Usings
    using SA.OnlineStore.Common.Entity;
    using System.Collections.Generic;
    #endregion

    public interface ISeasonService
    {
        IEnumerable<Season> GetSeasonList();
        //IEnumerable<string> SeasonNameList();
    }
}