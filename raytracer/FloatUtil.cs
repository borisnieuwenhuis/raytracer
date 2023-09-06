using System;
namespace raytracer
{
	public class FloatUtil
	{
		private const double EPSILON = 0.000001;

		public static bool eq(double a, double b)
		{
			return Math.Abs(a - b) < EPSILON;
		}
	}
}

