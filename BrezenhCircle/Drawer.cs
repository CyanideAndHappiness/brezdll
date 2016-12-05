using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;


namespace BrezDraw
{
    public static class Drawer
    {

        public static void DrawBresenhamLine(Graphics graphics, int x0, int y0, int x1, int y1)
        {
            bool steep = Math.Abs(y1 - y0) > Math.Abs(x1 - x0);

            // Если отрезок под крутым углом, меняем x и y для обеих точек местами
            if (steep)
            {
                Swap(ref x0, ref y0);
                Swap(ref x1, ref y1);
            }

            // Если конец отрезка левее начала отрезка, то меняем концы отрезка местами
            if (x0 > x1)
            {
                Swap(ref x0, ref x1);
                Swap(ref y0, ref y1);
            }

            // Общее приращение по x
            int dX = x1 - x0;
            // Модуль общего приращения по y
            int dY = Math.Abs(y1 - y0);

            // Ошибка
            int err = dX / 2;

            // Если линия идёт вверх, то приращение — 1, иначе — -1.
            int ystep = y0 < y1 ? 1 : -1;

            // Для первого y возьмём начальный y из левого конца отрезка
            int y = y0;

            // Цикл по x от левого конца отрезка до правого
            for (int x = x0; x <= x1; ++x)
            {
                // Если изначальный отрезок был крутой, то рисуем точку в (y,x) (выше обменяли x и y обоих концов)
                if (steep)
                {
                    SetPixel(graphics, Color.Black, y, x);
                }
                // в противном случае риусем «по-нормальному» точку в (x,y)
                else
                {
                    SetPixel(graphics, Color.Black, x, y);
                }

                // Поправляем ошибку
                err = err - dY;

                // Если ошибка отрицательная, y увеличиваем на вертикальный шаг (1 или -1)
                // и увеличиваем ошибку на шаг по x
                if (err < 0)
                {
                    y += ystep;
                    err += dX;
                }
            }
        }

        private static void SetPixel(Graphics g, Color col, int x, int y, int alpha = 127)
        {
            g.FillRectangle(new SolidBrush(Color.FromArgb(alpha, col)), x, y, 1, 1);
        }

        private static void Swap(ref int a, ref int b)
        {
            int t = a;
            a = b;
            b = t;
        }

        public static IEnumerable<Vector> GenerateCirclePoints(float x, float y, float radius)
        {
            double xC = 0, yC = radius;
            double delta = (2 - 2 * radius);
            while (yC >= 0)
            {
                yield return new Vector((int)(x + xC), (int)(y + yC));
                yield return new Vector((int)(x + xC), (int)(y - yC));
                yield return new Vector((int)(x - xC), (int)(y - yC));
                yield return new Vector((int)(x - xC), (int)(y + yC));

                var gap = 2 * (delta + yC) - 1;
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

        public static void BArc(Graphics g, Color clr, float x, float y, float radius, float alpha, float beta)
        {
            foreach (var point in GenerateCirclePoints(x, y, radius).Where(p => p.Y - y >= Math.Tan(alpha) * (p.X - x) && -p.Y + y <= Math.Tan(beta) * (p.X - x)))
            {
                SetPixel(g, clr, (int)point.X, (int)point.Y, 255);
            }
        }

        public static void BCircle(Graphics g, Color clr, float x, float y, float radius)
        {
            foreach (var point in GenerateCirclePoints(x, y, radius))
            {
                SetPixel(g, clr, (int)point.X, (int)point.Y, 255);
            }
        }
    }
}
