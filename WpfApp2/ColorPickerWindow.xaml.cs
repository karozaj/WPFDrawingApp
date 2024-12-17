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
        uint r;
        uint g;
        uint b;
        public delegate void SwitchColorDelegate(Color newColor);
        public ColorPickerWindow(Color col, SwitchColorDelegate switchColor)
        {
            
            InitializeComponent();
            rectangleColor.Fill = new SolidColorBrush(col);
            setTextBoxRGB(col);
            r = col.R;
            g = col.G;
            b = col.B;
            buttonAccept.Click += delegate
            {
                switchColor(Color.FromRgb(Convert.ToByte(r), Convert.ToByte(g), Convert.ToByte(b)));
                Close();
            };
        }

        void setTextBoxRGB(Color col)
        {
            textBoxR.Text = col.R.ToString();
            textBoxG.Text = col.G.ToString();
            textBoxB.Text = col.B.ToString();
        }



        new private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !e.Text.All(cc => Char.IsNumber(cc));
            base.OnPreviewTextInput(e);
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            uint val = 0;
            TextBox textBox = sender as TextBox;
            if(uint.TryParse(textBox.Text,out val))
            {
                if(val>255)
                {
                    textBox.Text = "255";
                }
                buttonAccept.IsEnabled = true;
            }
            else
            {
                buttonAccept.IsEnabled = false;
            }
            checkButtonEnabledCondition();
        }

        private void checkButtonEnabledCondition()
        {
            uint valR = 0;
            uint valG = 0;
            uint valB = 0;
            if (uint.TryParse(textBoxR.Text, out valR) && uint.TryParse(textBoxG.Text, out valG) && uint.TryParse(textBoxB.Text, out valB))
            {
                if (valR <= 255 && valG <= 255 && valB <= 255)
                {
                    r = valR;
                    g = valG;
                    b = valB;
                    setHSVInfo();
                    buttonAccept.IsEnabled=true;
                    return;
                }
            }
            buttonAccept.IsEnabled = false;
        }

        private void setHSVInfo()
        {
            double[] hsvInfo=colorConverter.RGBtoHSV(r, g, b);
            labelH.Content = Math.Round(hsvInfo[0]).ToString();
            labelS.Content = Math.Round(hsvInfo[1]).ToString();
            labelV.Content = Math.Round(hsvInfo[2]).ToString();
            rectangleColor.Fill = new SolidColorBrush(Color.FromRgb(Convert.ToByte(r), Convert.ToByte(g), Convert.ToByte(b)));
        }
    }
}
