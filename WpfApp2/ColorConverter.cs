using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    internal class ColorConverter
    {
        public double[] RGBtoHSV(uint r, uint g, uint b)
        {
            double[] hsvArray = new double[3];
            double rPrime = Convert.ToDouble(r)/ 255;
            double gPrime = Convert.ToDouble(g) / 255;
            double bPrime = Convert.ToDouble(b) / 255;
            double[] rgbPrime=new double[3];
            rgbPrime[0] = rPrime;
            rgbPrime[1] = gPrime;
            rgbPrime[2] = bPrime;
            double Cmax = rgbPrime.Max();
            double Cmin =rgbPrime.Min();
            double delta =Cmax-Cmin;
            //hue
            if (delta == 0.0)
            {
                hsvArray[0] = 0.0;
            }
            else if (Cmax == rPrime)
            {
                hsvArray[0] = 60.0 * ((((gPrime - bPrime) / delta) % 6));
            }
            else if (Cmax == gPrime)
            {
                hsvArray[0] = 60.0 * (((bPrime - rPrime) / delta) + 2.0);
            }
            else if (delta == bPrime)
            {
                hsvArray[0] = 60.0 * (((rPrime - gPrime) / delta) + 4.0);
            }
            if (hsvArray[0]<0)
            {
                hsvArray[0] += 360.0;
            }
            //saturation
            if(Cmax==0.0f)
            {
                hsvArray[1] = 0.0;
            }
            else
            {
                hsvArray[1] = delta / Cmax *100.0;
            }
            //VALUE
            hsvArray[2] = Cmax * 100.0;
            //hsvArray[0] = rPrime;
            //hsvArray[1] = gPrime;
            //hsvArray[2] = bPrime;
            return hsvArray;
        }
    }
}
