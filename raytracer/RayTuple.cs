using System;
using System.Numerics;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace raytracer
{
    public struct RayTuple
    {
        public const int Point = 1;
        public const int NegPoint = -1;
        public const int Vector = 0;

        private readonly double x;
        private readonly double y;
        private readonly double z;
        private readonly double w;

        public readonly double X { get { return x; } }
        public readonly double Y { get { return y; } }
        public readonly double Z { get { return z; } }
        public readonly double W { get { return w; } }

        public static RayTuple createPoint(double x, double y, double z)
        {
            return new RayTuple(Point, x, y, z);
        }

        public static RayTuple createVector(double x, double y, double z)
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
        public static RayTuple operator *(double b, RayTuple a) => new RayTuple(a.w * b, a.x * b, a.y * b, a.z * b);
        public static double operator *(RayTuple a, RayTuple b) => a.x * b.x + a.y * b.y + a.z * b.z + a.w * b.w;
        public static RayTuple operator -(RayTuple a, RayTuple b) {

            int resultType = isPoint(a) && isPoint(b) || isVector(a) && isVector(b) ? RayTuple.Vector : RayTuple.Point;
            return new RayTuple(resultType, a.x - b.x, a.y - b.y, a.z - b.z);
        }
        public static RayTuple operator -(RayTuple a) => new RayTuple(NegPoint, -1 * a.x, -1 * a.y, -1 * a.z);
        public static bool operator ==(RayTuple left, RayTuple right) => left.Equals(right);
        public static bool operator !=(RayTuple left, RayTuple right) => !(left == right);
      

        public RayTuple(double w, double x, double y, double z)
		{
			this.w = w;
			this.x = x;
			this.y = y;
			this.z = z;
		}

        public double magnitude()
        {
            return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2));
        }

        public RayTuple normalize()
        {
            double magnitude = this.magnitude();
            return RayTuple.createVector(this.X/magnitude, this.Y/magnitude, this.Z/magnitude);
        }

        public override readonly bool Equals(object? obj)
        {
            if (obj is null) 
            {
                return false;
            }
            if (obj is not RayTuple)
            {
                return false;
            }
            RayTuple rayTuple = (RayTuple)obj;
            return rayTuple.W == this.W && rayTuple.X == this.X &&
                rayTuple.Y == this.Y && rayTuple.Z == this.Z;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(x, y, z, w);
        }
        public override string ToString()
        {
            return System.String.Format("X:{0}, Y:{1}, Z:{2}, W:{3}", x, y, z, w);
        }

        public RayTuple cross(RayTuple r)
        {
            return RayTuple.createVector(
                this.y * r.z - this.z * r.y,
                this.z * r.x - this.x * r.z,
                this.x * r.y - this.y * r.x);

        }


    }
}

