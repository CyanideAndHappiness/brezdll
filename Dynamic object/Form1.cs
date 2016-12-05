using System;
using System.Drawing;
using System.Windows.Forms;
using BrezDraw;

namespace Dynamic_object
{
    public partial class Form1 : Form
    {
        private readonly SnowmanRenderer _snowmanRenderer;
        private readonly Snowman _snowman;

        public Form1()
        {
            InitializeComponent();

            _snowman = new Snowman();
            _snowmanRenderer = new SnowmanRenderer(SnowmanBox, _snowman);
            
            var timer = new Timer();
            timer.Tick += Timer_Tick;
            timer.Interval = 50;
            timer.Enabled = true;
        }
        


        private void Timer_Tick(object sender, EventArgs e)
        {
            _snowman.Tick();
            SnowmanBox.Invalidate();
        }


    }
}
