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
        private Pen p = new Pen(Color.Black);

        public Form1()
        {

            InitializeComponent();

            _bitmap = new Bitmap(SnowmanBox.Width, SnowmanBox.Height);
            _graphics = Graphics.FromImage(_bitmap);
            SnowmanBox.Resize += SnowmanBox_Resize;

            SnowmanBox.Paint += SnowmanBox_Paint1;


            Timer timer = new Timer();
            timer.Tick += Timer_Tick;
            timer.Interval = 200;
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

            _graphics.SmoothingMode = SmoothingMode.HighQuality;
         

            e.Graphics.DrawImage(_bitmap, 0f, 0f);
           
           

        }

        private void SnowmanBox_Paint1(object sender, PaintEventArgs e)
        {

           
        }

        private float _x;
       // private float _y;
     
      

        
        

        private void Timer_Tick(object sender, EventArgs e)
        {
            //_x += (float)_random.NextDouble() * 2f - 1f;
            //_y += (float)_random.NextDouble() * 2f - 1f;
        
                
            _x += 20f;
         //   _y += 0f;

            
            
                DrawSnowman(Color.Black);
           

            SnowmanBox.Invalidate();
            

        }

        

        private void DrawSnowman(Color clr)
        {
           
            
                _graphics.Clear(Color.Azure);

                Draw.BCircle(_graphics, clr, 120 + _x, 75, 35);
                Draw.BCircle(_graphics, clr, 120 + _x, 155, 45);
                Draw.BCircle(_graphics, clr, 120 + _x, 270, 70);
                Draw.BCircle(_graphics, clr, 103 + _x, 65, 4);
                Draw.BCircle(_graphics, clr, 130 + _x, 65, 4);

        }

     
      


    }
}
