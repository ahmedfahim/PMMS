using System;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.Configuration;
using System.Web.UI.WebControls;
using System.Drawing.Imaging;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace UtilitiesLibrary
{
    namespace Web
    {
        /// <summary>
        /// 
        /// </summary>
        public static class ImageProcessing
        {
            #region Private Methodes
            /// <summary>
            /// 
            /// </summary>
            /// <param name="file"></param>
            /// <returns></returns>
            private static bool IsImage(HttpPostedFile file)
            {
                //"^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))(.jpg|.JPG|.jpeg|.Jpeg|.gif|.GIF)$"
                return ((file != null) && System.Text.RegularExpressions.Regex.IsMatch(file.ContentType, "image/\\S+") && (file.ContentLength > 0));
            }
            /// <summary>
            /// Get from WebConfig MaxRequestLength
            /// </summary>
            /// <param name="ApplicationPath"></param>
            /// <returns></returns>
            private static int? MaxRequestLength(string ApplicationPath)
            {
                try
                {
                    Configuration config = WebConfigurationManager.OpenWebConfiguration(ApplicationPath);
                    HttpRuntimeSection section = config.GetSection("system.web/httpRuntime") as HttpRuntimeSection;
                    return section.MaxRequestLength;
                }
                catch
                {
                    return null;
                }

            }
            /// <summary>
            /// Get the desired Codec
            /// </summary>
            /// <param name="ImagePath"></param>
            /// <returns></returns>
            private static ImageCodecInfo GetEncoderInfo(String ImagePath)
            {
                string Extension = null;
                if (Path.HasExtension(ImagePath))
                {
                    Extension = "*" + Path.GetExtension(ImagePath).ToUpper();
                    ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();
                    for (int j = 0; j < encoders.Length; ++j)
                    {
                        if (encoders[j].FilenameExtension.Contains(Extension))
                            return encoders[j];

                    }
                    return null;
                }
                else
                    return null;
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="oldSize"></param>
            /// <param name="targetSize"></param>
            /// <returns></returns>
            private static Size CalculateDimensions(Size oldSize, int targetSize)
            {
                Size newSize = new Size();
                if (oldSize.Height > oldSize.Width)
                {
                    newSize.Width = (int)(oldSize.Width * ((float)targetSize / (float)oldSize.Height));
                    newSize.Height = targetSize;
                }
                else
                {
                    newSize.Width = targetSize;
                    newSize.Height = (int)(oldSize.Height * ((float)targetSize / (float)oldSize.Width));
                }
                return newSize;
            }
            #endregion

            #region Public Methods
            /// <summary>
            /// 
            /// </summary>
            /// <param name="imgUpload"></param>
            /// <returns></returns>
            public static byte[] GetPhoto(FileUpload imgUpload)
            {
                //Byte[] imgByte = null;
                if (imgUpload != null && imgUpload.HasFile && imgUpload.PostedFile != null &&
                    imgUpload.PostedFile.ContentType.StartsWith("image"))
                {
                    ////To create a PostedFile
                    //HttpPostedFile File = imgUpload.PostedFile;
                    ////Create byte Array with file lenth
                    //imgByte = new Byte[File.ContentLength];
                    ////force the control to load data in array
                    //File.InputStream.Read(imgByte, 0, File.ContentLength);
                    //return imgByte;
                    return imgUpload.FileBytes;
                }
                else
                    return null;

            }
            /// <summary>
            /// Max Limte File 
            /// 1048576 B = 1024 KB = 1 MB 
            /// </summary>
            /// <param name="file">Pass FileUpload.PostedFile </param>
            /// <param name="size">Set Your Limte Size</param>
            /// <returns>Boolean value</returns>
            public static bool IsSizeLessThan(HttpPostedFile file, int maxSizeKB)
            {
                return ((file != null) && (file.ContentLength <= (maxSizeKB * 1024)));
            }
            /// <summary>
            /// Max Limte File 
            /// 1048576 B = 1024 KB = 1 MB
            /// </summary>
            /// <param name="file">Pass FileUpload.PostedFile</param>
            /// <param name="maxSizeKB">Set Your Limte Size</param>
            /// <returns>String Message FileSize Or Warning Message </returns>
            public static string ValidFileSize(HttpPostedFile file, int maxSizeKB)
            {
                double SizeKB = file.ContentLength / 1024.0;
                string message;
                if (!IsSizeLessThan(file, maxSizeKB))
                    message = string.Format("Make sure your file is under {0:0.#} MB.", maxSizeKB / 1024);
                else
                    if (SizeKB > 1024)
                        message = string.Format("file size is {0:0.#} MB.", SizeKB / 1024.0);
                    else
                        message = string.Format("file size is {0:0.#} KB.", SizeKB);
                return message;
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="context"></param>
            /// <param name="StrmPhoto"></param>
            /// <param name="MaxPhotoSize"></param>
            /// <returns></returns>
            public static bool DrawingPhoto(HttpContext context, Stream StrmPhoto)
            {
                if (context != null && StrmPhoto != null)
                {
                    int? MaxPhotoSize = MaxRequestLength(context.Request.ApplicationPath);
                    if (MaxPhotoSize.HasValue)
                    {
                        try
                        {
                            byte[] buffer = new byte[MaxPhotoSize.Value];
                            int byteSeq = StrmPhoto.Read(buffer, 0, MaxPhotoSize.Value);
                            while (byteSeq > 0)
                            {
                                context.Response.OutputStream.Write(buffer, 0, byteSeq);
                                byteSeq = StrmPhoto.Read(buffer, 0, MaxPhotoSize.Value);
                            }
                            StrmPhoto.Dispose();
                            return true;
                        }
                        catch
                        {
                            return false;
                        }
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="context"></param>
            /// <param name="BytePhoto"></param>
            /// <returns></returns>
            public static bool DrawingPhoto(HttpContext context, byte[] BytePhoto)
            {
                if (BytePhoto != null)
                {
                    MemoryStream StrmPhoto = new MemoryStream(BytePhoto);
                    return DrawingPhoto(context, StrmPhoto);

                }
                else
                    return false;
            }
            /// <summary>
            /// Get the desired Encoder and Quality
            /// </summary>
            /// <param name="ImagePath"></param>
            /// <param name="newImagePath"></param>
            /// <param name="lCompression"></param>
            /// <returns></returns>
            public static bool SaveCompressionImage(string ImagePath, string newImagePath, long lCompression)
            {
                MemoryStream memoryStream = SaveCompressionImage(ImagePath, lCompression);
                if (memoryStream != null && memoryStream.Length < new FileInfo(ImagePath).Length * (lCompression / 100.0))
                {
                    try
                    {
                        Bitmap.FromStream(memoryStream).Save(newImagePath);
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
                else
                    return false;
            }
            /// <summary>
            /// Get the desired Encoder and Quality
            /// </summary>
            /// <param name="ImagePath"></param>
            /// <param name="lCompression"></param>
            /// <returns></returns>
            public static MemoryStream SaveCompressionImage(string ImagePath, long lCompression)
            {
                ImageCodecInfo ici = GetEncoderInfo(ImagePath);
                if (ici != null)
                {
                    try
                    {
                        MemoryStream memoryStream = new MemoryStream();
                        Bitmap ImgTemp = new Bitmap(ImagePath);
                        EncoderParameters eps = new EncoderParameters(1);
                        eps.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, lCompression);
                        ImgTemp.Save(memoryStream, ici, eps);
                        return memoryStream;
                    }
                    catch
                    {
                        return null;
                    }

                }
                else
                    return null;
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="imageFile"></param>
            /// <param name="targetSize"></param>
            /// <returns></returns>
            public static byte[] ResizeImageFile(byte[] imageFile, int targetSize)
            {
                using (System.Drawing.Image oldImage = System.Drawing.Image.FromStream(new MemoryStream(imageFile)))
                {
                    Size newSize = CalculateDimensions(oldImage.Size, targetSize);
                    return ResizeImageFile(imageFile, newSize);
                }

            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="imageFile"></param>
            /// <param name="targetSize"></param>
            /// <returns></returns>
            public static byte[] ResizeImageFile(byte[] imageFile, Size targetSize)
            {
                using (System.Drawing.Image oldImage = System.Drawing.Image.FromStream(new MemoryStream(imageFile)))
                {
                    using (Bitmap newImage = new Bitmap(targetSize.Width, targetSize.Height, PixelFormat.Format24bppRgb))
                    {
                        using (Graphics canvas = Graphics.FromImage(newImage))
                        {
                            canvas.SmoothingMode = SmoothingMode.AntiAlias;
                            canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            canvas.PixelOffsetMode = PixelOffsetMode.HighQuality;
                            canvas.DrawImage(oldImage, new Rectangle(new Point(0, 0), targetSize));
                            MemoryStream m = new MemoryStream();
                            newImage.Save(m, ImageFormat.Jpeg);
                            return m.GetBuffer();
                        }
                    }
                }

            }
            #endregion


          

             
            
        } 
    }
}
