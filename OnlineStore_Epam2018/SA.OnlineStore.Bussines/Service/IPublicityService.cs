using SA.OnlineStore.Bussines.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA.OnlineStore.Bussines.Service
{
    public interface IPublicityService
    {
        Publicity GetPublicity();
        IEnumerable<Publicity> GetPublicityList();
    }
}
