namespace SA.OnlineStore.WCF
{
    #region Usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    #endregion
    public class MakingPublicityList
    {
        Random r = new Random();
        List<Publicity> listPublicity = new List<Publicity>()
            {
                new Publicity()
        {
            Id = 1,
                    Name = "Реклама_1",
                    Text = "Текст_1"
                },
                new Publicity()
        {
            Id = 2,
                    Name = "Реклама_2",
                    Text = "Текст_2"
                },
                new Publicity()
        {
            Id = 3,
                    Name = "Реклама_3",
                    Text = "Текст_3"
                },
                new Publicity()
        {
            Id = 4,
                    Name = "Реклама_4",
                    Text = "Текст_4"
                },
                new Publicity()
        {
            Id = 5,
                    Name = "Реклама_5",
                    Text = "Текст_5"
                },
                new Publicity()
        {
            Id = 6,
                    Name = "Реклама_6",
                    Text = "Текст_6"
                },
                new Publicity()
        {
            Id = 7,
                    Name = "Реклама_7",
                    Text = "Текст_7"
                },
                new Publicity()
        {
            Id = 8,
                    Name = "Реклама_8",
                    Text = "Текст_8"
                },
                new Publicity()
        {
            Id = 9,
                    Name = "Реклама_9",
                    Text = "Текст_9"
                },
                new Publicity()
        {
            Id = 10,
                    Name = "Реклама_10",
                    Text = "Текст_10"
                }

            };

        public List<Publicity> ReturnPublicityList()
        {
            int counter = 3;
            int countPublicity = listPublicity.Count();
            List<Publicity> resultList = new List<Publicity>();
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