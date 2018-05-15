using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SA.OnlineStore.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "NewWebService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select NewWebService.svc or NewWebService.svc.cs at the Solution Explorer and start debugging.
    public class NewWebService : INewWebService
    {
        MakingPublicityList makingPublicityList = new MakingPublicityList();

        public IEnumerable<Publicity> GetPublicityList()
        {
            return makingPublicityList.ReturnPublicityList();
        }
    }
}
