using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrezDraw;

namespace Dynamic_object
{
    /// <summary>
    /// Рендерер снеговика
    /// </summary>
    public class SnowmanRenderer
    {
        private readonly Control _control;
        private Image _image;
        private Graphics _bitmapGraphics;

        private readonly Brush _orangeBrush = new SolidBrush(Color.Orange);
        private readonly Color _blackColor = Color.Black;

        private readonly Snowman _snowman;

        public SnowmanRenderer(Control control, Snowman snowman)
        {
            _snowman = snowman;
            _snowman.MaxX = control.Width;

            _control = control;
            _image = new Bitmap(_control.Width, _control.Height);
            _bitmapGraphics = Graphics.FromImage(_image);

            control.Paint += Control_Paint;
            control.Resize += Control_Resize;
        }

        private void Control_Resize(object sender, EventArgs e)
        {
            _snowman.MaxX = _control.Width;
            _image = new Bitmap(_control.Width, _control.Height);
            _bitmapGraphics = Graphics.FromImage(_image);

            _control.Invalidate();
        }

        private void Control_Paint(object sender, PaintEventArgs e)
        {
            _bitmapGraphics.SmoothingMode = SmoothingMode.HighQuality;
            _bitmapGraphics.Clear(Color.Azure);

            Drawer.BCircle(_bitmapGraphics, _blackColor, 120 + _snowman.Position.X, 75 + _snowman.Position.Y, 35);
            Drawer.BCircle(_bitmapGraphics, _blackColor, 120 + _snowman.Position.X, 155 + _snowman.Position.Y, 45);
            Drawer.BCircle(_bitmapGraphics, _blackColor, 120 + _snowman.Position.X, 270 + _snowman.Position.Y, 70);
            Drawer.BCircle(_bitmapGraphics, _blackColor, 103 + _snowman.Position.X, 65 + _snowman.Position.Y, 4);
            Drawer.BCircle(_bitmapGraphics, _blackColor, 130 + _snowman.Position.X, 65 + _snowman.Position.Y, 4);
            
            Drawer.BArc(_bitmapGraphics, _blackColor, 120 + _snowman.Position.X, 75 + _snowman.Position.Y, 25, (float)Math.PI / 4f, (float)Math.PI / 4f * 5f);

            Drawer.DrawBresenhamLine(_bitmapGraphics,
                (int)(120 + _snowman.Position.X + 45), 155 + (int)_snowman.Position.Y,
                (int)(120 + _snowman.Position.X + 45 + _snowman.ArmLength * Math.Cos(_snowman.ArmAngle)), (int)(155 + +_snowman.Position.Y - _snowman.ArmLength * Math.Sin(_snowman.ArmAngle)));
            Drawer.DrawBresenhamLine(_bitmapGraphics,
                (int)(120 + _snowman.Position.X - 45), (int)(155 + _snowman.Position.Y),
                (int)(120 + _snowman.Position.X - 45 - 50), (int) (155 - 50 + _snowman.Position.Y));

            _bitmapGraphics.FillPolygon(_orangeBrush, new[] { new PointF(120 + _snowman.Position.X - 6, 75f + _snowman.Position.Y), new PointF(120 + _snowman.Position.X - 6 + 20f, 75f + 5f + _snowman.Position.Y), new PointF(120 + _snowman.Position.X - 6, 75f + 10f + _snowman.Position.Y) });

            e.Graphics.DrawImage(_image, 0f, 0f);
        }
    }
}
