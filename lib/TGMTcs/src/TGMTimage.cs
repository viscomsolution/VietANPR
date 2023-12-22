using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace TGMTcs
{
    public class TGMTimage
    {

        public static Bitmap CorrectOrientation(Bitmap bmp)
        {
            if (Array.IndexOf(bmp.PropertyIdList, 274) > -1)
            {
                var orientation = (int)bmp.GetPropertyItem(274).Value[0];
                switch (orientation)
                {
                    case 1:
                        // No rotation required.
                        break;
                    case 2:
                        bmp.RotateFlip(RotateFlipType.RotateNoneFlipX);
                        break;
                    case 3:
                        bmp.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        break;
                    case 4:
                        bmp.RotateFlip(RotateFlipType.Rotate180FlipX);
                        break;
                    case 5:
                        bmp.RotateFlip(RotateFlipType.Rotate90FlipX);
                        break;
                    case 6:
                        bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        break;
                    case 7:
                        bmp.RotateFlip(RotateFlipType.Rotate270FlipX);
                        break;
                    case 8:
                        bmp.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        break;
                }
                // This EXIF data is now invalid and should be removed.
                bmp.RemovePropertyItem(274);
            }
            return bmp;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string ImageToBase64(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            byte[] filebytes = new byte[fs.Length];
            fs.Read(filebytes, 0, Convert.ToInt32(fs.Length));
            fs.Close();
            return "data:image/png;base64," + Convert.ToBase64String(filebytes, Base64FormattingOptions.None);

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static Image Base64ToImage(string base64String)
        {
            // Convert base 64 string to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            // Convert byte[] to Image
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string ImageToBase64(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, ImageFormat.Jpeg);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to base 64 string
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private static ImageCodecInfo GetJpegCodec()
        {
            foreach (ImageCodecInfo c in ImageCodecInfo.GetImageEncoders())
            {
                if (c.CodecName.ToLower().Contains("jpeg")
                    || c.FilenameExtension.ToLower().Contains("*.jpg")
                    || c.FormatDescription.ToLower().Contains("jpeg")
                    || c.MimeType.ToLower().Contains("image/jpeg"))
                    return c;
            }

            return null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool IsImage(string fileName)
        {
            if (fileName.Contains(" "))
            {
                return false;
            }
            string ext = Path.GetExtension(fileName).ToLower();
            return (ext == ".jpg" || ext == ".png" || ext == ".bmp");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool IsBase64(string base64String)
        {
            // Credit: oybek https://stackoverflow.com/users/794764/oybek
            if (base64String == null || base64String.Length == 0 || base64String.Length % 4 != 0
               || base64String.Contains(" ") || base64String.Contains("\t") || base64String.Contains("\r") || base64String.Contains("\n"))
                return false;

            return true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static Bitmap ResizeBitmap(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static Bitmap ResizeBitmapByWidth(Image image, int width)
        {
            float ratio = (float)image.Width / (float)image.Height;
            int height = (int)((float)width / ratio);

            return ResizeBitmap(image, width, height);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static Image ResizeImageByWidth(Image image, int width)
        {
            float ratio = (float)image.Width / (float)image.Height;
            int height = (int)((float)width / ratio);

            return ResizeBitmap(image, width, height);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static Bitmap CropBitmap(Bitmap bmp, Rectangle rect)
        {
            Bitmap target = new Bitmap(rect.Width, rect.Height);
            using (Graphics g = Graphics.FromImage(target))
            {
                g.DrawImage(bmp, new Rectangle(0, 0, target.Width, target.Height),
                                 rect,
                                 GraphicsUnit.Pixel);
                return target;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        
        public static Image CaptureScreen(Rectangle roi)
        {
            if (roi.Width == 0 || roi.Height == 0)
                return null;

            Bitmap target = new Bitmap(roi.Width, roi.Height);
            using (Graphics g = Graphics.FromImage(target))
            {
                g.CopyFromScreen(roi.X, roi.Y, 0, 0, new Size(roi.Width, roi.Height));
            }
            return target;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static Bitmap LoadBitmapWithoutLock(string imagePath)
        {
            if (!File.Exists(imagePath))
                return null;
            string ext = Path.GetExtension(imagePath).ToLower();
            if(ext == ".jpg" || ext == ".png" || ext == ".bmp")
            {
                var bytes = File.ReadAllBytes(imagePath);
                var ms = new MemoryStream(bytes);
                var img = Image.FromStream(ms, true);
                return (Bitmap)img;
            }
            return null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static byte[] ImageToBytes(Image image, ImageFormat imageFormat)
        {
            byte[] imageBytes;
            try
            {
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    image.Save(ms, imageFormat);
                    imageBytes = ms.ToArray();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return imageBytes;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static Image BytesToImage(byte[] imageBytes)
        {
            Image image;
            try
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBytes);
                image = Image.FromStream(ms);
            }
            catch (Exception)
            {
                throw;
            }
            return image;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static Bitmap RotateImage(Bitmap bmp, float angle)
        {
            Bitmap rotatedImage = new Bitmap(bmp.Width, bmp.Height);
            rotatedImage.SetResolution(bmp.HorizontalResolution, bmp.VerticalResolution);

            using (Graphics g = Graphics.FromImage(rotatedImage))
            {
                // Set the rotation point to the center in the matrix
                g.TranslateTransform(bmp.Width / 2, bmp.Height / 2);
                // Rotate
                g.RotateTransform(angle);
                // Restore rotation point in the matrix
                g.TranslateTransform(-bmp.Width / 2, -bmp.Height / 2);
                // Draw the image on the bitmap
                g.DrawImage(bmp, new Point(0, 0));
            }

            return rotatedImage;
        }
    }
}
