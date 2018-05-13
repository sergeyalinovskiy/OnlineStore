namespace SA.OnlineStore.Bussines.Service
{
    #region Usings
    using SA.OnlineStore.Common.Entity;
    using System.Collections.Generic;
    #endregion

    public interface ISeasonService
    {
        IEnumerable<SeasonModel> GetSeasonList();
        IEnumerable<string> SeasonNameList();
    }
}