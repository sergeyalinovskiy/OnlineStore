using SA.OnlineStore.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.OnlineStore.DataAccess.Service
{
    public interface IPublicityRepository
    {
          PublicityWcf GetPublicity();
        IEnumerable<PublicityWcf> GetPublicityList();
    }
}
