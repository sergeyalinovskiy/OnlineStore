using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SA.OnlineStore.WCF
{
    [ServiceContract]
    public interface INewWebService
    {
        [OperationContract]
        IEnumerable<Publicity> GetPublicityList();
    }
}
