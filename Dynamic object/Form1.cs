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
        private Pen blackPen = new Pen(new SolidBrush(Color.Black), 1.5f);
        private Brush orb = new SolidBrush(Color.Orange);

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
            e.Graphics.DrawImage(_bitmap, 0f, 0f);
        }

        private void SnowmanBox_Paint1(object sender, PaintEventArgs e)
        {


        }

        private float _vx = 10f;
        private float _x;
        private float _alpha = 0f;
        private float _vAlpha = 0.05f;
        private float _handLength = 70.71f;


        private void Timer_Tick(object sender, EventArgs e)
        {

            if (_x + 120 + 95 > SnowmanBox.Width || _x < 0f)
            {
                _vx = -_vx;
            }

            _alpha += _vAlpha;

            if (Math.Abs(_alpha) > Math.PI / 6)
            {
                _vAlpha = -_vAlpha;
            }

            _x += _vx;
            DrawSnowman(Color.Black);
            SnowmanBox.Invalidate();
        }



        private void DrawSnowman(Color clr)
        {
            //_graphics.SmoothingMode = SmoothingMode.HighQuality;
            
            _graphics.Clear(Color.Azure);

            Draw.BCircle(_graphics, clr, 120 + _x, 75, 35);
            Draw.BCircle(_graphics, clr, 120 + _x, 155, 45);
            Draw.BCircle(_graphics, clr, 120 + _x, 270, 70);
            Draw.BCircle(_graphics, clr, 103 + _x, 65, 4);
            Draw.BCircle(_graphics, clr, 130 + _x, 65, 4);

            Draw.DrawBresenhamLine(_graphics, (int)(120 + _x + 45), (int)(155), (int)(120 + _x + 45 + (float)_handLength * Math.Cos(_alpha)), (int)(155 - _handLength * Math.Sin(_alpha)));
            Draw.DrawBresenhamLine(_graphics, (int)(120 + _x - 45), 155, (int)(120 + _x - 45 - 50), 155 - 50);

            _graphics.FillPolygon(orb, new[] { new PointF(120 + _x - 6, 75f), new PointF(120 + _x - 6 + 20f, 75f + 5f), new PointF(120 + _x - 6, 75f + 10f) });

        }

    }
}
