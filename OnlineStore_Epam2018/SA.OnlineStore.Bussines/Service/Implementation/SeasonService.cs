namespace SA.OnlineStore.Bussines.Components
{
    #region Usings
    using SA.OnlineStore.Bussines.Service;
    using SA.OnlineStore.Common.Entity;
    using SA.OnlineStore.DataAccess.Implements;
    using SA.OnlineStore.DataAccess.Service;
    using System;
    using System.Collections.Generic;
    #endregion

    public class SeasonService : ISeasonService
    {
        private readonly IRepository<Season> _seasonRepository;
        public SeasonService(IRepository<Season> seasonRepository)
        {
            _seasonRepository = seasonRepository;
        }

        public IEnumerable<Season> GetSeasonList()
        {
            return _seasonRepository.GetAll();
        }

        public IEnumerable<string> SeasonNameList()
        {
            List<string> seasonNames = new List<string>();
            foreach (Season item in _seasonRepository.GetAll())
            {
                seasonNames.Add(item.SeasonName);
            }
            return seasonNames;
        }
    }
}
