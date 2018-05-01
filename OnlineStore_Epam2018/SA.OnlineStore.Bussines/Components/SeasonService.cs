using SA.OnlineStore.Bussines.Entity;
using SA.OnlineStore.Bussines.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.OnlineStore.Bussines.Components
{
    public class SeasonService : ISeasonService
    {

        public List<Season> _seasons = new List<Season>();
        public List<string> _seasonNames = new List<string>();

        public SeasonService()
        {
            Create(new Season
            {
                SeasonName = "лето"
            });
            Create(new Season
            {
                SeasonName = "осень"
            });
            Create(new Season
            {
                SeasonName = "зима"
            });
        }

        public void Create(Season model)
        {
            _seasons.Add(model);
        }

        public Season GetSeason(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Season> GetSeasonList()
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
