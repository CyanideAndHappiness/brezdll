using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;


namespace BrezDraw
{
    public class Draw
    {

        Bitmap pixel;
        Bitmap bmp;
        MemoryStream mem;

        private void DrawPixel()
        {
            pixel = new Bitmap(1, 1);
            pixel.SetPixel(0, 0, Color.Black);
            mem = new MemoryStream();
            bmp = new Bitmap(pixel);
        }


        private static void SetMyPixel(Graphics g, Color col, int x, int y, int alpha)
        {
            g.FillRectangle(new SolidBrush(Color.FromArgb(alpha, col)), x, y, 1, 1);
        }


        public static void BCircle(Graphics g, Color clr, double x, double y, double radius)
        {


            double xC = 0, yC = radius, gap = 0, delta = (2 - 2 * radius);
            while (yC >= 0)
            {
                SetMyPixel(g, clr, (int)(x + xC), (int)(y + yC), 255);
                SetMyPixel(g, clr, (int)(x + xC), (int)(y - yC), 255);
                SetMyPixel(g, clr, (int)(x - xC), (int)(y - yC), 255);
                SetMyPixel(g, clr, (int)(x - xC), (int)(y + yC), 255);
                gap = 2 * (delta + yC) - 1;
                if (delta < 0 && gap <= 0)
                {
                    xC++;
                    delta += 2 * xC + 1;
                    continue;
                }
                if (delta > 0 && gap > 0)
                {
                    yC--;
                    delta -= 2 * yC + 1;
                    continue;
                }
                xC++;
                delta += 2 * (xC - yC);
                yC--;
            }
        }
    }
}
