using System;
using System.Drawing;

namespace WebApplication1.Models
{
    public static class GenerateImage 
    {
        public static string GetDefaultBase64Image(string text, Font font, Color textColor, Color backColor, int height, int width)
        {
            // get first text
            text = text.Trim().ToUpper()[0].ToString();

            // get image
            Image img = GetDefaultImage(text, font, textColor, backColor, height, width);

            // convert to image array
            ImageConverter converter = new ImageConverter();
            byte[] imageArray = (byte[])converter.ConvertTo(img, typeof(byte[]));

            // return base64image
            return @"data:image/jpg;base64," + Convert.ToBase64String(imageArray);
        }

        private static Image GetDefaultImage(string text, Font font, Color textColor, Color backColor, int height, int width)
        {
            // first, create a dummy bitmap just to get a graphics object
            Image img = new Bitmap(1, 1);
            Graphics drawing = Graphics.FromImage(img);

            // measure the string to see how big the image needs to be
            SizeF textSize = drawing.MeasureString(text, font);

            // free up the dummy image and old graphics object
            img.Dispose();
            drawing.Dispose();

            // create a new image of the right size
            img = new Bitmap(height, width);

            drawing = Graphics.FromImage(img);

            // paint the background
            drawing.Clear(backColor);

            // create a brush for the text
            Brush brush = new SolidBrush(textColor);

            // string alignment
            StringFormat stringFormat = new StringFormat();
            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat.Alignment = StringAlignment.Center;

            // rectangular
            RectangleF rectangleF = new RectangleF(0, 0, img.Width, img.Height);

            // draw text on image
            drawing.DrawString(text, font, brush, rectangleF, stringFormat);

            // save drawing
            drawing.Save();

            // dispose
            brush.Dispose();
            drawing.Dispose();

            // return image
            return img;
        }
    }
}