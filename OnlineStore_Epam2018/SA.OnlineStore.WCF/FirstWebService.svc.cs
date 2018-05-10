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
        public int add(int x, int y)
        {
            return x * y;
        }
        public string Message()
        {
            return "wqqwdwqwq";
        }

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
            return new List<Publicity>()
            {
                new Publicity()
                {
                    Id=1,
                    Name="Реклама_1",
                    Text="Текст_1"
                },
                new Publicity()
                {
                    Id=2,
                    Name="Реклама_2",
                    Text="Текст_2"
                },
                new Publicity()
                {
                    Id=3,
                    Name="Реклама_3",
                    Text="Текст_3"
                },
                new Publicity()
                {
                    Id=4,
                    Name="Реклама_4",
                    Text="Текст_4"
                },
                new Publicity()
                {
                    Id=5,
                    Name="Реклама_5",
                    Text="Текст_5"
                },
                new Publicity()
                {
                    Id=6,
                    Name="Реклама_6",
                    Text="Текст_6"
                },
                new Publicity()
                {
                    Id=7,
                    Name="Реклама_7",
                    Text="Текст_7"
                },
                new Publicity()
                {
                    Id=8,
                    Name="Реклама_8",
                    Text="Текст_8"
                },
                new Publicity()
                {
                    Id=9,
                    Name="Реклама_9",
                    Text="Текст_9"
                },
                 new Publicity()
                {
                    Id=10,
                    Name="Реклама_10",
                    Text="Текст_10"
                }

            };
        }

       
    }
}
