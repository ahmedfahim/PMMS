using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing.Drawing2D;

/// <summary>
/// Summary description for ImagesClass
/// </summary>
public class ImagesClass
{
	public ImagesClass()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public static Bitmap ResizeBitmap(Bitmap src, int newWidth, int newHeight)
    {
        Bitmap result = new Bitmap(newWidth, newHeight);
        using (Graphics g = Graphics.FromImage((System.Drawing.Image)result))
        {
            g.DrawImage(src, 0, 0, newWidth, newHeight);
        }

        return result;
    }

    public static void ResizeImage(Stream from, Stream to, ImageFormat format, int width, int height)
    {
        using (Image img = Image.FromStream(from))
        {
            using (Bitmap resizedBitmap = new Bitmap(width, height))
            {
                using (Graphics resizedGraph = Graphics.FromImage(resizedBitmap))
                {
                    resizedGraph.CompositingQuality = CompositingQuality.HighQuality;
                    resizedGraph.SmoothingMode = SmoothingMode.HighQuality;
                    resizedGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;

                    Rectangle rect = new Rectangle(0, 0, width, height);
                    resizedGraph.DrawImage(img, rect);
                    resizedBitmap.Save(to, img.RawFormat);
                }
            }
        }
    }

    public static void ResizeImagePutWatermark(Stream from, Stream to, ImageFormat format, int width, int height, bool putWatermark, string watermarkText)
    {
        using (Image img = Image.FromStream(from, true, false))
        {
            using (Bitmap resizedBitmap = new Bitmap(width, height))
            {
                using (Graphics resizedGraph = Graphics.FromImage(resizedBitmap))
                {
                    resizedGraph.CompositingQuality = CompositingQuality.HighQuality;
                    resizedGraph.SmoothingMode = SmoothingMode.HighQuality;
                    resizedGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;

                    Rectangle rect = new Rectangle(0, 0, width, height);
                    resizedGraph.DrawImage(img, rect);

                    if (putWatermark)
                    {
                        int fontSize = ((resizedBitmap.Width * 2) / (watermarkText.Length * 3));
                        int x = resizedBitmap.Width / 2;
                        int y = resizedBitmap.Height * 9 / 10;

                        StringFormat drawFormat = new StringFormat();
                        drawFormat.Alignment = StringAlignment.Center;
                        drawFormat.FormatFlags = StringFormatFlags.NoWrap;

                        resizedGraph.SmoothingMode = SmoothingMode.AntiAlias;
                        resizedGraph.DrawString(watermarkText, new Font("Verdana", fontSize, FontStyle.Bold), new SolidBrush(Color.FromArgb(80, 255, 255, 255)), x, y, drawFormat);
                    }

                    resizedBitmap.Save(to, img.RawFormat);
                }
            }

            img.Dispose();
        }
    }

    public static string WaterMarkImage(Bitmap bmp, string tmpName, string watermarkText, string uploadsFolder)
    {
        //string watermark = "Waleed M Alhasan - " + DateTime.Today.ToString("dd/MM/yyyy");
        int fontSize = ((bmp.Width * 2) / (watermarkText.Length * 3));
        int x = bmp.Width / 2;
        int y = bmp.Height * 9 / 10;

        StringFormat drawFormat = new StringFormat();
        drawFormat.Alignment = StringAlignment.Center;
        drawFormat.FormatFlags = StringFormatFlags.NoWrap;

        Graphics g = Graphics.FromImage(bmp);
        g.DrawString(watermarkText, new Font("Verdana", fontSize, FontStyle.Bold), new SolidBrush(Color.FromArgb(80, 255, 255, 255)), x, y, drawFormat);

        //string watermarkedImageFileName = HttpContext.Current.Server.MapPath("~/uploads/") + tmpName;
        string watermarkedImageFileName = uploadsFolder + tmpName;
        bmp.Save(watermarkedImageFileName);

        return watermarkedImageFileName;
    }


}
