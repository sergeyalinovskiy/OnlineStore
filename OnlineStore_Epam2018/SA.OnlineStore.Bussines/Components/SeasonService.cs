
using SA.OnlineStore.Bussines.Service;
using SA.OnlineStore.Common.Entity;
using SA.OnlineStore.DataAccess.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.OnlineStore.Bussines.Components
{
    public class SeasonService : ISeasonService
    {
        private readonly ISeasonRepository _seasonRepository;
        public SeasonService(ISeasonRepository seasonRepository)
        {
            _seasonRepository = seasonRepository;
        }
        public void Create(SeasonModel model)
        {
            throw new NotImplementedException();
        }

        public SeasonModel GetSeason(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SeasonModel> GetSeasonList()
        {
            return _seasonRepository.GetSeasonList();
        }

        public IEnumerable<string> SeasonNameList()
        {
            List<string> seasonNames = new List<string>();
            foreach (SeasonModel item in _seasonRepository.GetSeasonList())
            {
                seasonNames.Add(item.SeasonName);
            }
            return seasonNames;
        }
    }
}
