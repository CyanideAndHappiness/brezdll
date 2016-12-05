using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_object
{
    /// <summary>
    /// Структура вектор
    /// </summary>
    public struct Vector
    {
        public float X { get; }
        public float Y { get; }

        public Vector(float x, float y)
        {
            X = x;
            Y = y;
        }
    }
}
