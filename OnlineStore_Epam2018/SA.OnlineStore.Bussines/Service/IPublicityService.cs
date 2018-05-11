
using SA.OnlineStore.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.OnlineStore.Bussines.Service
{
    public interface IPublicityService
    {
        PublicityModel GetPublicity();
        IEnumerable<PublicityModel> GetPublicityList();
    }
}
