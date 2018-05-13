namespace SA.OnlineStore.WCF
{
    #region Usings
    using System.Collections.Generic;
    #endregion

    public class FirstWebService : IFirstWebService
    {
        MakingPublicityList makingPublicityList = new MakingPublicityList();
   
        public IEnumerable<Publicity> GetPublicityList()
        {
           return makingPublicityList.ReturnPublicityList();
        }
    }
}
