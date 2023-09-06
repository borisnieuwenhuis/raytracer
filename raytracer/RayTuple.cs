using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace raytracer
{
    public struct RayTuple
    {
        public const int Point = 1;
        public const int Vector = 0;

        private readonly int x;
        private readonly int y;
        private readonly int z;
        private readonly int w;

        public readonly int X { get { return x; } }
        public readonly int Y { get { return y; } }
        public readonly int Z { get { return z; } }
        public readonly int W { get { return w; } }

        public static RayTuple createPoint(int x, int y, int z)
        {
            return new RayTuple(Point, x, y, z);
        }

        public static RayTuple createVector(int x, int y, int z)
        {
            return new RayTuple(Vector, x, y, z);
        }

        public static bool isPoint(RayTuple rayTuple)
        {
            return rayTuple.W == RayTuple.Point;
        }

        public static bool isVector(RayTuple rayTuple)
        {
            return rayTuple.W == RayTuple.Vector;
        }

        public static RayTuple operator +(RayTuple a, RayTuple b) => new RayTuple(Vector, a.x + b.x, a.y + b.y, a.z + b.z);

        public static RayTuple operator -(RayTuple a, RayTuple b) {

            int resultType = isPoint(a) && isPoint(b) || isVector(a) && isVector(b) ? RayTuple.Vector : RayTuple.Point;
            return new RayTuple(resultType, a.x - b.x, a.y - b.y, a.z - b.z);
        }

        public RayTuple(int w, int x, int y, int z)
		{
			this.w = w;
			this.x = x;
			this.y = y;
			this.z = z;
		}

		
	}
}

