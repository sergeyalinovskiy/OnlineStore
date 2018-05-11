
using SA.OnlineStore.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.OnlineStore.Bussines.Service
{
    public interface ISeasonService
    {
        void Create(SeasonModel model);
        SeasonModel GetSeason(int Id);
        IEnumerable<SeasonModel> GetSeasonList();
        IEnumerable<string> SeasonNameList();
    }
}
