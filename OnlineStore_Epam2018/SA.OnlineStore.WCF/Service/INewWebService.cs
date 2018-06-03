using System.Collections.Generic;
using System.ServiceModel;

namespace SA.OnlineStore.WCF
{
    [ServiceContract]
    public interface INewWebService
    {
        [OperationContract]
        IEnumerable<PublicityService> GetPublicityList();
    }
}