using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Logika interakcji dla klasy ColorPickerWindow.xaml
    /// </summary>
    public partial class ColorPickerWindow : Window
    {
        private ColorConverter colorConverter= new ColorConverter();
        int r;
        int g;
        int b;
        public ColorPickerWindow(Color col)
        {
            
            InitializeComponent();
            rectangleColor.Fill = new SolidColorBrush(col);
            setTextBoxRGB(col);
            r = col.R;
            g = col.G;
            b = col.B;
        }

        void setTextBoxRGB(Color col)
        {
            textBoxR.Text = col.R.ToString();
            textBoxG.Text = col.G.ToString();
            textBoxB.Text = col.B.ToString();
        }



        private void textBoxR_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void textBoxG_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void textBoxB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }
    }
}
