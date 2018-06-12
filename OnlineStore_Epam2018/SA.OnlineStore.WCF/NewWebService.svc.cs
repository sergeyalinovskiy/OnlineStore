using SA.OnlineStore.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SA.OnlineStore.WCF
{
    public class NewWebService : INewWebService
    {
        MakingPublicityList makingPublicityList = new MakingPublicityList();

        public IEnumerable<PublicityService> GetPublicityList()
        {
            return makingPublicityList.ReturnPublicityList();
        }
    }
}
