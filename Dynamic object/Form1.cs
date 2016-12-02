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

        public Form1()
        {

            InitializeComponent();

            _bitmap = new Bitmap(SnowmanBox.Width, SnowmanBox.Height);
            _graphics = Graphics.FromImage(_bitmap);
            SnowmanBox.Resize += SnowmanBox_Resize;
        }

        private void SnowmanBox_Resize(object sender, EventArgs e)
        {
            _bitmap = new Bitmap(SnowmanBox.Width, SnowmanBox.Height);
            _graphics = Graphics.FromImage(_bitmap);
        }

        private void SnowmanBox_Paint(object sender, PaintEventArgs e)
        {
            
            var graphics = _graphics;
            var clr = Color.Black;

            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.Clear(Color.AliceBlue);

  
            BrezDraw.Draw.BCircle(_graphics, clr, 120, 75, 35);
            BrezDraw.Draw.BCircle(_graphics, clr, 120, 155, 45);
            BrezDraw.Draw.BCircle(_graphics, clr, 120, 270, 70);

            e.Graphics.DrawImage(_bitmap, 0f, 0f);

        }
    }
}
