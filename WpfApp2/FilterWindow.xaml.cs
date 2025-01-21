using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Logika interakcji dla klasy FilterWindow.xaml
    /// </summary>
    public partial class FilterWindow : Window
    {
        Canvas canvas;
        //string regexPattern = @"[-]?[0123456789]+";

        public FilterWindow(Canvas canv)
        {
            InitializeComponent();
            canvas = canv;
        }

        new private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !e.Text.All(cc => Char.IsNumber(cc) || cc == '-');
            base.OnPreviewTextInput(e);
        }

        private void btnConfirmFilter_Click(object sender, RoutedEventArgs e)
        {
            WriteableBitmap wb = ImageManager.CanvasToWriteableBitmap(canvas);
            Bitmap b = ImageManager.WriteableBitmapToBitmap(wb);
            Image<Bgr, byte> img = b.ToImage<Bgr, byte>();

            //split image into channels
            Image<Gray,byte> blue = img.Split()[0];
            Image<Gray, byte> green = img.Split()[1];
            Image<Gray, byte> red = img.Split()[2];

            //create filter matrix
            float[,] matrix = new float[3, 3]{
                { float.Parse(fn1n1.Text),  float.Parse(f0n1.Text),  float.Parse(fp1n1.Text) },
                {float.Parse(fn10.Text),  float.Parse(f00.Text),  float.Parse(fp10.Text) },
                { float.Parse(fp1n1.Text),  float.Parse(f0p1.Text),  float.Parse(fp1p1.Text) }
            };
            float sum = 0;
            for(int i=0;i<=2;i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    sum += matrix[i,j];
                }
            }
            if (sum == 0)
            {
                return;
            }
            for (int i = 0; i <= 2; i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    matrix[i, j] = matrix[i,j]/sum;
                }
            }
            ConvolutionKernelF matrixKernel = new ConvolutionKernelF(matrix);
            //apply filter
            var blueF = new Mat(blue.Size, Emgu.CV.CvEnum.DepthType.Cv8U, 1);
            CvInvoke.Filter2D(blue, blueF, matrixKernel, new System.Drawing.Point(0, 0));
            var greenF = new Mat(green.Size, Emgu.CV.CvEnum.DepthType.Cv8U, 1);
            CvInvoke.Filter2D(green, greenF, matrixKernel, new System.Drawing.Point(0, 0));
            var redF = new Mat(red.Size, Emgu.CV.CvEnum.DepthType.Cv8U, 1);
            CvInvoke.Filter2D(red, redF, matrixKernel, new System.Drawing.Point(0, 0));

            //reassemble image
            Mat mat = new Mat();
            CvInvoke.Merge(new VectorOfMat(blueF, greenF, redF), mat);
            Image<Bgr,byte> reconstructed=new Image<Bgr,byte>(mat);
            Bitmap bmp = reconstructed.ToBitmap();
            canvas.Children.Clear();
            canvas.Background=new ImageBrush(ImageManager.BitmapToBitmapSource(bmp));

        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            int res = 0;
            if(int.TryParse(fn1n1.Text,out res) && int.TryParse(f0n1.Text, out res) && int.TryParse(fp1n1.Text, out res) &&
                int.TryParse(fn10.Text, out res) && int.TryParse(f00.Text, out res) && int.TryParse(fp10.Text, out res) &&
                int.TryParse(fn1p1.Text, out res) && int.TryParse(f0p1.Text, out res) && int.TryParse(fp1p1.Text, out res))
            {
                btnConfirmFilter.IsEnabled = true;
            }
            else
            { btnConfirmFilter.IsEnabled = false; }
        }
    }
}
