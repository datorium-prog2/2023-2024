using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public struct Vector
    {
        public Vector(float endX, float endY, float startX = 0, float startY = 0)
        {
            this.startX = startX;
            this.startY = startY;
            this.endX = endX;
            this.endY = endY;
        }

        public float startX;
        public float startY;
        public float endX;
        public float endY;

        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v2.endX, v2.endY, v1.startX, v1.startY);
        }

        public override string ToString()
        {
            return $"{startX} {startY} {endX} {endY}";
        }
    }

    public class VectorSum
    {
        public VectorSum()
        {
            Vector vectorA = new Vector(4, 4);
            Vector vectorB = new Vector(4, 8, 4, 4);
            Vector vectorAB = vectorA + vectorB;

            Console.WriteLine(vectorAB);
        }

    }
}
