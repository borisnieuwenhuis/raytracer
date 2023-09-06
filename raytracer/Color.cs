using System;
using System.Drawing;
using System.Numerics;
using System.Reflection.Metadata;

namespace raytracer
{
	public class Color: Tuple<double, double, double>
    {
        public static readonly Color Black = new Color(0, 0, 0);

        public Color(double item1, double item2, double item3) : base(item1, item2, item3)
        {
        }

        public double R { get { return this.Item1; } }
        public double G { get { return this.Item2; } }
        public double B { get { return this.Item3; } }

        public static Color operator +(Color a, Color b) => new Color(a.R + b.R, a.G + b.G, a.B + b.B);
        public static Color operator -(Color a, Color b) => new Color(a.R - b.R, a.G - b.G, a.B - b.B);
        public static Color operator *(int x, Color a) => new Color(x * a.R, x * a.G, x * a.B );
        public static Color operator *(Color a, Color b) => new Color(a.R * b.R, a.G * b.G, a.B * b.B);
        public static bool operator ==(Color left, Color right) => left.Equals(right);
        public static bool operator !=(Color left, Color right) => !(left == right);


        public override bool Equals(object? obj)
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
            return FloatUtil.eq(color.R, this.R) && FloatUtil.eq(color.G, this.G) &&
                FloatUtil.eq(color.B, this.B);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(R, G, B);
        }
    }
}

