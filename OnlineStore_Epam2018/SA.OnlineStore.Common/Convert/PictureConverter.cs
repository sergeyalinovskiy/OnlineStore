﻿using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace SA.OnlineStore.Common.Convert
{
    public static class PictureConverter
    {
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
