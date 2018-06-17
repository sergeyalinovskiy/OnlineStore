namespace SA.OnlineStore.Service
{
    using SA.OnlineStore.WCF;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;

    #region Usings
    using System;
    using System.Collections.Generic;
    using System.Linq;
    #endregion
   
    public class MakingPublicityList
    {
        
        Random r = new Random();

        static string ProjectFolder = "11111";
        List<PublicityService> listPublicity = new List<PublicityService>()
            {
              
                new PublicityService()
        {
                    Id = 1,
                    Name = "Реклама_1",
                    Text = "Текст_1",
                    Picture=ImageToByteArray(GetImg("D:\\"+ProjectFolder+"\\OnlineStore\\OnlineStore_Epam2018\\SA.OnlineStore.WCF\\Content\\Images\\7.jpg"))
                },
                new PublicityService()
        {
                    Id = 2,
                    Name = "Реклама_2",
                    Text = "Текст_2",
                     Picture=ImageToByteArray(GetImg("D:\\"+ProjectFolder+"\\OnlineStore\\OnlineStore_Epam2018\\SA.OnlineStore.WCF\\Content\\Images\\7.jpg"))
                },
                new PublicityService()
        {
                    Id = 3,
                    Name = "Реклама_3",
                    Text = "Текст_3",
                     Picture=ImageToByteArray(GetImg("D:\\"+ProjectFolder+"\\OnlineStore\\OnlineStore_Epam2018\\SA.OnlineStore.WCF\\Content\\Images\\7.jpg"))
                },
                new PublicityService()
        {
                    Id = 4,
                    Name = "Реклама_4",
                    Text = "Текст_4",
                     Picture=ImageToByteArray(GetImg("D:\\"+ProjectFolder+"\\OnlineStore\\OnlineStore_Epam2018\\SA.OnlineStore.WCF\\Content\\Images\\7.jpg"))
                },
                new PublicityService()
        {
                    Id = 5,
                    Name = "Реклама_5",
                    Text = "Текст_5",
                     Picture=ImageToByteArray(GetImg("D:\\"+ProjectFolder+"\\OnlineStore\\OnlineStore_Epam2018\\SA.OnlineStore.WCF\\Content\\Images\\7.jpg"))
                },
                new PublicityService()
        {
                    Id = 6,
                    Name = "Реклама_6",
                    Text = "Текст_6",
                    Picture=ImageToByteArray(GetImg("D:\\"+ProjectFolder+"\\OnlineStore\\OnlineStore_Epam2018\\SA.OnlineStore.WCF\\Content\\Images\\7.jpg"))
                },
                new PublicityService()
        {       
                    Id = 7,
                    Name = "Реклама_7",
                    Text = "Текст_7",
                     Picture=ImageToByteArray(GetImg("D:\\"+ProjectFolder+"\\OnlineStore\\OnlineStore_Epam2018\\SA.OnlineStore.WCF\\Content\\Images\\7.jpg"))
                },
                new PublicityService()
        {
                    Id = 8,
                    Name = "Реклама_8",
                    Text = "Текст_8",
                     Picture=ImageToByteArray(GetImg("D:\\"+ProjectFolder+"\\OnlineStore\\OnlineStore_Epam2018\\SA.OnlineStore.WCF\\Content\\Images\\7.jpg"))
                },
                new PublicityService()
        {
                    Id = 9,
                    Name = "Реклама_9",
                    Text = "Текст_9",
                    Picture=ImageToByteArray(GetImg("D:\\"+ProjectFolder+"\\OnlineStore\\OnlineStore_Epam2018\\SA.OnlineStore.WCF\\Content\\Images\\7.jpg"))
                },
                new PublicityService()
        {
                    Id = 10,
                    Name = "Реклама_10",
                    Text = "Текст_10",
                     Picture=ImageToByteArray(GetImg("D:\\"+ProjectFolder+"\\OnlineStore\\OnlineStore_Epam2018\\SA.OnlineStore.WCF\\Content\\Images\\7.jpg"))
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








        public static Image GetImg(string way)
        {
            Image image = Image.FromFile(way);
            return image;
        }

        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public static byte[] ImageToByteArray(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        private static Image BitmapToImage(Bitmap map)
        {
            Stream imageStream = new MemoryStream();
            map.Save(imageStream, ImageFormat.Png);
            return Image.FromStream(imageStream);
        }

        public static byte[] GetNormalizedImage(byte[] img, int width, int height)
        {
            Image tempImg = byteArrayToImage(img);
            Bitmap map = new Bitmap(tempImg, width, height);
            Image newImg = BitmapToImage(map);
            return ImageToByteArray(newImg);
        }
    }
}