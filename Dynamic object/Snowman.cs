using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_object
{
    /// <summary>
    /// Снеговик
    /// </summary>
    public class Snowman
    {
        public Vector Position { get; set; } = new Vector(120f, 0f);
        public Vector Velocity { get; set; } = new Vector(2.5f, 0f);
        public float ArmLength { get; set; } = 72f;
        public float ArmAngle { get; set; }
        public float ArmAngleVelocity { get; set; } = 0.05f;
        public float MaxX { get; set; }
        
        public void Tick()
        {
            if (Position.X + 120 + 95 > MaxX) Velocity =  new Vector(-Math.Abs(Velocity.X), Velocity.Y);
            if (Position.X < 0f) Velocity = new Vector(Math.Abs(Velocity.X), Velocity.Y);
            ArmAngle += ArmAngleVelocity;
            if (Math.Abs(ArmAngle) > Math.PI / 6) ArmAngleVelocity = -ArmAngleVelocity;
            Position = new Vector(Position.X + Velocity.X, Position.Y + Velocity.Y);
        }
    }
}
