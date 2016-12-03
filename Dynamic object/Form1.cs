using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using BrezDraw;

namespace Dynamic_object
{
    public partial class Form1 : Form
    {
        private Bitmap _bitmap;
        private Graphics _graphics;
        private Random _random = new Random();

        public Form1()
        {

            InitializeComponent();

            _bitmap = new Bitmap(SnowmanBox.Width, SnowmanBox.Height);
            _graphics = Graphics.FromImage(_bitmap);
            SnowmanBox.Resize += SnowmanBox_Resize;

            SnowmanBox.Paint += SnowmanBox_Paint1;


            Timer timer = new Timer();
            timer.Tick += Timer_Tick;
            timer.Interval = 50;
            timer.Enabled = true;
        }

        private void SnowmanBox_Resize(object sender, EventArgs e)
        {
            _bitmap = new Bitmap(SnowmanBox.Width, SnowmanBox.Height);
            _graphics = Graphics.FromImage(_bitmap);
        }

        private void SnowmanBox_Paint(object sender, PaintEventArgs e)
        {

            //var graphics = _graphics;
            //var clr = Color.Black;

            //graphics.SmoothingMode = SmoothingMode.HighQuality;
            //graphics.Clear(Color.AliceBlue);

            //DrawSnowman(clr, 0f, 0f);

            //e.Graphics.DrawImage(_bitmap, 0f, 0f);
            
            e.Graphics.DrawImage(_bitmap, 0f, 0f);
        }

        private void SnowmanBox_Paint1(object sender, PaintEventArgs e)
        {

            //DrawSnowman(Color.AliceBlue, x, y);
        }

        private float _x;
        private float _y;

        private void Timer_Tick(object sender, EventArgs e)
        {
            _x += (float)_random.NextDouble() * 2f - 1f;
            _y += (float)_random.NextDouble() * 2f - 1f;
            DrawSnowman(Color.Black);
            SnowmanBox.Invalidate();

        }

        private void DrawSnowman(Color clr)
        {
            _graphics.Clear(Color.Azure);
            Draw.BCircle(_graphics, clr, 120 + _x*2, 75 + _y, 35);
            Draw.BCircle(_graphics, clr, 120 + _x*2, 155 + _y, 45);
            Draw.BCircle(_graphics, clr, 120 + _x*2, 270 + _y, 70);
        }

        // Bitmap pixel;

        //void myLineBrez(Graphics gr, double x1, double y1)
        //{

        //    double k, error, x0, y0;
        //    x0 = 0; y0 = 0;
        //    error = 0;

        //    while (x0 < x1)
        //    {
        //        gr.DrawImage(pixel, (int)x0, (int)y0);
        //        k = Math.Abs((y1 - y0) / (x1 - x0));
        //        error = error + k;

        //        if (error < 0.5)
        //        {
        //            x0 = x0 + 1;
        //            gr.DrawImage(pixel, (int)x0, (int)y0);
        //        }

        //        if (error > 0.5)
        //        {
        //            x0 = x0 + 1; y0 = y0 + 1;
        //            gr.DrawImage(pixel, (int)x0, (int)y0);
        //            error = error - 1;
        //        }
        //        if (error == k)
        //        {
        //            gr.DrawImage(pixel, (int)x0, (int)y0);
        //        }
        //    }
        //    return; 
        //}


    }
}
