namespace SA.OnlineStore.WCF
{
    #region Usings
    using System.Collections.Generic;
    using System.ServiceModel;
    #endregion

    [ServiceContract]
    public interface IFirstWebService
    {
        [OperationContract]
        IEnumerable<Publicity> GetPublicityList();
    }
}
