using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace raytracer
{
	public struct RayTuple
	{
        public const int Point = 1;
        public const int Vector= 0;

        private readonly int x;
        private readonly int y;
        private readonly int z;
        private readonly int w;

        public static RayTuple createPoint(int x, int y, int z)
		{
			return new RayTuple(Point, x, y, z);
		}

        public static RayTuple createVector(int x, int y, int z)
        {
            return new RayTuple(Vector, x, y, z);
        }

        public static RayTuple operator +(RayTuple a, RayTuple b) => new RayTuple(Vector, a.x + b.x, a.y + b.y, a.z + b.z);

        public RayTuple(int w, int x, int y, int z)
		{
			this.w = w;
			this.x = x;
			this.y = y;
			this.z = z;
		}

		
	}
}

