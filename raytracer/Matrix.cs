using System;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
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
        public static Matrix operator *(Matrix left, Matrix right) {
            Matrix m = new Matrix(4, 4);
            for (int i = 0; i < m.values.GetLongLength(0); i++)
            {
                for (int j = 0; j < m.values.GetLongLength(1); j++)
                {
                    double[] row = left.Row(i);
                    double[] column = right.Column(j);
                    var pairs = row.Zip(column, (row, column) => row * column);
                    m.values[i, j] = pairs.Sum();
                }
            }
            return m;
        }

        public static Tuple<double, double, double, double> operator *(Matrix left, Tuple<double, double, double, double> right)
        {
            double[] result = new double[4];

            for (int i = 0; i < 4; i++)
            {
                double[] row = left.Row(i);
                RayTuple leftTuple = new RayTuple(row[0], row[1], row[2], row[3]);
                RayTuple rightTuple = new RayTuple(right.Item1, right.Item2, right.Item3, right.Item4);

                result[i] = leftTuple * rightTuple;

            }

            return Tuple.Create(result[0], result[1], result[2], result[3]);
        }

        public override string ToString()
        {

            List<String> rows = new List<string>();
            for (int i = 0; i < values.GetLongLength(0); i++)
            {
                List<String> row = new List<string>();
                for (int j = 0; j < values.GetLongLength(1); j++)
                {
                    row.Add(values[i, j].ToString());
                }
                rows.Add(String.Join("|", row));
            }
            return String.Join("\n", rows);
        }

        public double[] Row(int i)
        {
            return Enumerable.Range(0, values.GetLength(0))
                .Select(x => values[i, x])
                .ToArray();
        }

        public double[] Column(int i)
        {
            return Enumerable.Range(0, values.GetLength(1))
                .Select(x => values[x, i])
                .ToArray();
        }

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

