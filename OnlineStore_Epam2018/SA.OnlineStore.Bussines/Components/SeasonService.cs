
using SA.OnlineStore.Bussines.Service;
using SA.OnlineStore.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.OnlineStore.Bussines.Components
{
    public class SeasonService : ISeasonService
    {

        public List<SeasonModel> _seasons = new List<SeasonModel>();
        public List<string> _seasonNames = new List<string>();

        public SeasonService()
        {
            Create(new SeasonModel
            {
                SeasonName = "лето"
            });
            Create(new SeasonModel
            {
                SeasonName = "осень"
            });
            Create(new SeasonModel
            {
                SeasonName = "зима"
            });
        }

        public void Create(SeasonModel model)
        {
            _seasons.Add(model);
        }

        public SeasonModel GetSeason(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SeasonModel> GetSeasonList()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> SeasonNameList()
        {
            foreach (var item in _seasons)
            {
                if (_seasons.Count > _seasonNames.Count)  // УБРАТЬ! (когда будет база...)
                {
                    _seasonNames.Add(item.SeasonName);
                }
            }
            return _seasonNames;
        }
    }
}
