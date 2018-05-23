namespace SA.OnlineStore.Bussines.Components
{
    #region Usings
    using SA.OnlineStore.Bussines.Service;
    using SA.OnlineStore.Common.Entity;
    using SA.OnlineStore.DataAccess.Service;
    using System;
    using System.Collections.Generic;
    #endregion

    public class SeasonService : ISeasonService
    {
        private readonly ISeasonRepository _seasonRepository;
        public SeasonService(ISeasonRepository seasonRepository)
        {
            _seasonRepository = seasonRepository;
        }

        public IEnumerable<Season> GetSeasonList()
        {
            return _seasonRepository.GetSeasonList();
        }

        public IEnumerable<string> SeasonNameList()
        {
            List<string> seasonNames = new List<string>();
            foreach (Season item in _seasonRepository.GetSeasonList())
            {
                seasonNames.Add(item.SeasonName);
            }
            return seasonNames;
        }
    }
}
