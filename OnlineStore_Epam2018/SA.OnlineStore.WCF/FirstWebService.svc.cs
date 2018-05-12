using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml.Linq;

namespace SA.OnlineStore.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FirstWebService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select FirstWebService.svc or FirstWebService.svc.cs at the Solution Explorer and start debugging.
    public class FirstWebService : IFirstWebService
    {
        MakingPublicityList makingPublicityList = new MakingPublicityList();
        public Publicity GetPublicity(int id)
        {
            var result = new Publicity();
            result.Id = 1;
            result.Name = "Error";
            result.Text = "132";
            return result;
        }
        
        
        public IEnumerable<Publicity> GetPublicityList()
        {
           return makingPublicityList.ReturnPublicityList();
        }
    }
}
