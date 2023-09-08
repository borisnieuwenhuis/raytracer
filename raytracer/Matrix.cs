using System;
using System.Runtime.InteropServices;

namespace raytracer
{
	public class Matrix
	{
        private double[,] values;

        public Matrix(long x, long y)
		{
            values = new double[x, y];
        }

        public void Set(long x, long y, double value)
        {
            values[x, y] = value;
        }

        public double Get(long x, long y)
        {
            return values[x, y];
        }

        public static bool operator ==(Matrix left, Matrix right) => left.Equals(right);
        public static bool operator !=(Matrix left, Matrix right) => !(left == right);

        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }
            if (obj is not Matrix)
            {
                return false;
            }
            Matrix matrix = (Matrix)obj;
            if (values.GetLongLength(0) != matrix.values.GetLongLength(0))
            {
                return false;
            }
            if (values.GetLongLength(1) != matrix.values.GetLongLength(1))
            {
                return false;
            }

            for (int i=0; i< values.GetLongLength(0); i++)
            {
                for (int j = 0; j < values.GetLongLength(1); j++)
                {
                    if (!FloatUtil.eq(values[i, j], matrix.values[i, j]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(values);
        }


    }
}

