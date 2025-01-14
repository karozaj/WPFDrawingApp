using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.Windows.Interop;
using Emgu.CV.Structure;
using Emgu.CV;
using Microsoft.Win32;

namespace WpfApp2
{
    static class ImageManager
    {
        static public System.Drawing.Bitmap WriteableBitmapToBitmap(WriteableBitmap writeBmp)
        {
            System.Drawing.Bitmap bmp;
            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder be = new BmpBitmapEncoder();
                be.Frames.Add(BitmapFrame.Create((BitmapSource)writeBmp));
                be.Save(outStream);
                bmp = new System.Drawing.Bitmap(outStream);
            }
            return bmp;
        }

        static public WriteableBitmap CanvasToWriteableBitmap(Canvas canvas)
        {
            // Save current canvas transform
            Transform transform = canvas.LayoutTransform;
            // reset current transform (in case it is scaled or rotated)
            canvas.LayoutTransform = null;

            // Get the size of canvas
            System.Windows.Size size = new System.Windows.Size(canvas.ActualWidth, canvas.ActualHeight);
            // Measure and arrange the surface
            // VERY IMPORTANT
            canvas.Measure(size);
            canvas.Arrange(new Rect(size));

            // Create a render bitmap and push the surface to it
            RenderTargetBitmap renderBitmap = new RenderTargetBitmap(
              (int)size.Width,
              (int)size.Height,
              96d,
              96d,
              PixelFormats.Pbgra32);
            renderBitmap.Render(canvas);


            //Restore previously saved layout
            WriteableBitmap wbmp= new WriteableBitmap(renderBitmap);
            canvas.Children.Clear();
            canvas.Width = wbmp.Width;
            canvas.Height = wbmp.Height;
            canvas.Background = new ImageBrush(wbmp);

            //canvas.LayoutTransform = transform;
            //create and return a new WriteableBitmap using the RenderTargetBitmap
            //WriteableBitmap test= new WriteableBitmap(renderBitmap);
            //paintSurface.Background = new ImageBrush(test);
            return wbmp;

        }

        static public BitmapSource BitmapToBitmapSource(Bitmap bmp)
        {
            return Imaging.CreateBitmapSourceFromHBitmap(bmp.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        //static public Image<Bgr,byte> CanvasToImage(Canvas canvas)
        //{
        //    WriteableBitmap wb = CanvasToWriteableBitmap(canvas);
        //    Bitmap b = WriteableBitmapToBitmap(wb);
        //    Image<Bgr, byte> img = b.ToImage<Bgr, byte>();
        //    return img;
        //}

        static public void FilterSobel(Canvas canvas)
        {
            WriteableBitmap wb = CanvasToWriteableBitmap(canvas);
            Bitmap b = WriteableBitmapToBitmap(wb);
            Image<Bgr, byte> img = b.ToImage<Bgr, byte>();
            CvInvoke.Sobel(img, img, Emgu.CV.CvEnum.DepthType.Default, 1, 0);
            //paintSurface.Background = new ImageBrush(img.ToBitmap());
            Bitmap b2 = img.ToBitmap();
            canvas.Background = new ImageBrush(BitmapToBitmapSource(b2));
        }

        static public void SaveToFile(string filename, Canvas surface)
        {
            WriteableBitmap img = ImageManager.CanvasToWriteableBitmap(surface);

            //encode as PNG
            if (filename.EndsWith(".png"))
            {
                BitmapEncoder pngEncoder = new PngBitmapEncoder();
                pngEncoder.Frames.Add(BitmapFrame.Create(img));

                //save to memory stream
                System.IO.MemoryStream ms = new System.IO.MemoryStream();

                pngEncoder.Save(ms);
                ms.Close();
                System.IO.File.WriteAllBytes(filename, ms.ToArray());
            }
            else if (filename.EndsWith(".jpg") || filename.EndsWith(".jpeg"))
            {
                BitmapEncoder jpgEncoder = new JpegBitmapEncoder();
                jpgEncoder.Frames.Add(BitmapFrame.Create(img));

                //save to memory stream
                System.IO.MemoryStream ms = new System.IO.MemoryStream();

                jpgEncoder.Save(ms);
                ms.Close();
                System.IO.File.WriteAllBytes(filename, ms.ToArray());
            }
        }
    }
}
