namespace SA.OnlineStore.WCF
{
    using SA.OnlineStore.Common.Convert;
    #region Usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    #endregion
    public class MakingPublicityList
    {
        Random r = new Random();
        List<PublicityService> listPublicity = new List<PublicityService>()
            {
                new PublicityService()
        {
                    Id = 1,
                    Name = "Реклама_1",
                    Text = "Текст_1",
                    Picture="D:\\111\\OnlineStore\\OnlineStore_Epam2018\\SA.OnlineStore.WCF\\Content\\Images\\2.jpg"
                },
                new PublicityService()
        {
                    Id = 2,
                    Name = "Реклама_2",
                    Text = "Текст_2",
                     Picture="D:\\111\\OnlineStore\\OnlineStore_Epam2018\\SA.OnlineStore.WCF\\Content\\Images\\4.jpg"
                },
                new PublicityService()
        {
                    Id = 3,
                    Name = "Реклама_3",
                    Text = "Текст_3",
                     Picture="D:\\111\\OnlineStore\\OnlineStore_Epam2018\\SA.OnlineStore.WCF\\Content\\Images\\5.jpg"
                },
                new PublicityService()
        {
                    Id = 4,
                    Name = "Реклама_4",
                    Text = "Текст_4",
                     Picture="D:\\111\\OnlineStore\\OnlineStore_Epam2018\\SA.OnlineStore.WCF\\Content\\Images\\6.jpg"
                },
                new PublicityService()
        {
                    Id = 5,
                    Name = "Реклама_5",
                    Text = "Текст_5",
                     Picture="OnlineStore_Epam2018\\SA.OnlineStore.WCF\\Content\\Images\\7.jpg"
                },
                new PublicityService()
        {
                    Id = 6,
                    Name = "Реклама_6",
                    Text = "Текст_6",
                    Picture="OnlineStore_Epam2018\\SA.OnlineStore.WCF\\Content\\Images\\8.jpg"
                },
                new PublicityService()
        {       
                    Id = 7,
                    Name = "Реклама_7",
                    Text = "Текст_7",
                     Picture="OnlineStore_Epam2018/SA.OnlineStore.WCF/Content/Images/9.jpg"
                },
                new PublicityService()
        {
                    Id = 8,
                    Name = "Реклама_8",
                    Text = "Текст_8",
                     Picture="SA.OnlineStore.WCF//Content//Images//2.jpg"

                },
                new PublicityService()
        {
                    Id = 9,
                    Name = "Реклама_9",
                    Text = "Текст_9",
                    Picture="OnlineStore_Epam2018//SA.OnlineStore.WCF//Content//Images//5.jpg"
                },
                new PublicityService()
        {
                    Id = 10,
                    Name = "Реклама_10",
                    Text = "Текст_10",
                     Picture="OnlineStore_Epam2018/SA.OnlineStore.WCF/Content/Images/8.jpg"
                }

            };

        public List<PublicityService> ReturnPublicityList()
        {
            int counter = 3;
            int countPublicity = listPublicity.Count();
            List<PublicityService> resultList = new List<PublicityService>();
            while (counter != 0)
            {
                int a=r.Next(0, countPublicity);
                resultList.Add(listPublicity[a]);
                counter--;
            }
            return resultList;
        }
    }
}