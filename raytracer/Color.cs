using System;
using System.Numerics;
using System.Reflection.Metadata;

namespace raytracer
{
	public class Color: Tuple<int, int ,int>
    {
        private readonly double r;
        private readonly double g;
        private readonly double b;

        public readonly double R { get { return this.Item1; } }
        public readonly double G { get { return this.Item2; } }
        public readonly double B { get { return this.Item3; } }

        public static Color operator +(Color a, Color b) => new Color(a.r + b.r, a.g + b.g, a.b + b.b);
        public static Color operator -(Color a, Color b) => new Color(a.r - b.r, a.g - b.g, a.b - b.b);
        public static Color operator *(int x, Color a) => new Color(x * a.r, x * a.g, x * a.b );

        public Color(double r, double g, double b)
		{
            this.r = r;
            this.g = g;
            this.b = b;
        }

        public override readonly bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }
            if (obj is not Color)
            {
                return false;
            }
            Color color = (Color)obj;
            return FloatUtil.eq(color.r, this.r) && FloatUtil.eq(color.g, this.g) &&
                FloatUtil.eq(color.b, this.b);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(r, g, b);
        }

        public override string ToString()
        {
            return System.String.Format("R:{0}, G:{1}, B:{2}", r, g, b);
        }
    }
}

