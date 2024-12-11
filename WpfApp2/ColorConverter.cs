using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    internal class ColorConverter
    {
        public float[] RGBtoHSV(int r, int g, int b)
        {
            float[] hsvArray = new float[3];
            float rPrime =r/255;
            float gPrime =g/255;
            float bPrime =b/255;
            float[] rgbPrime=new float[3];
            rgbPrime[0] = rPrime;
            rgbPrime[1] = gPrime;
            rgbPrime[2] = bPrime;
            float Cmax = rgbPrime.Max();
            float Cmin =rgbPrime.Min(); 
            float delta=Cmax-Cmin;
            //hue
            if (delta == 0.0f)
            {
                hsvArray[0] = 0.0f;
            }
            else if (Cmax == rPrime)
            {
                hsvArray[0] = 60 * (((gPrime - bPrime) / delta) % 6);
            }
            else if (Cmax == gPrime)
            {
                hsvArray[0] = 60 * (((bPrime - rPrime) / delta) + 2);
            }
            else if (delta == bPrime)
            {
                hsvArray[0] = 60 * (((rPrime - gPrime) / delta) + 4);
            }
            //saturation
            if(Cmax==0.0f)
            {
                hsvArray[1] = 0.0f;
            }
            else
            {
                hsvArray[1] = delta / Cmax;
            }
            //VALUE
            hsvArray[2] = Cmax;
            return hsvArray;
        }
    }
}
