namespace SA.OnlineStore.Bussines.Components
{
    #region Usings
    using SA.OnlineStore.Bussines.Service;
    using SA.OnlineStore.Common.Entity;
    using SA.OnlineStore.DataAccess.Implements;
    using SA.OnlineStore.DataAccess.Repositorys;
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
    }
}
