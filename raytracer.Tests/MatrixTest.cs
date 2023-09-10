using System;
using System.Diagnostics;

namespace raytracer.Tests
{
	public class MatrixTest
	{
		[Fact]
		public void testValues2X2()
		{
			Matrix m = new Matrix(2, 2);
			m.Set(0, 0, -3);
            m.Set(0, 1, 5);
            m.Set(1, 0, 1);
            m.Set(1, 1, -2);

			Assert.Equal(-3, m.Get(0, 0));
            Assert.Equal(5, m.Get(0, 1));
        }

        [Fact]
        public void testEquals()
        {
            Matrix m1 = new Matrix(2, 2);
            m1.Set(0, 0, -3);
            m1.Set(0, 1, 5);
            m1.Set(1, 0, 1);
            m1.Set(1, 1, -2);

            Matrix m2 = new Matrix(2, 2);
            m2.Set(0, 0, -3);
            m2.Set(0, 1, 5);
            m2.Set(1, 0, 1);
            m2.Set(1, 1, -2);

            Assert.Equal(m1, m2);
        }

        [Fact]
        public void testNotEquals()
        {
            Matrix m1 = new Matrix(2, 2);
            m1.Set(0, 0, 2);
            m1.Set(0, 1, 5);
            m1.Set(1, 0, 1);
            m1.Set(1, 1, -2);

            Matrix m2 = new Matrix(2, 2);
            m2.Set(0, 0, -3);
            m2.Set(0, 1, 5);
            m2.Set(1, 0, 1);
            m2.Set(1, 1, -2);

            Assert.NotEqual(m1, m2);
        }

        private void fillMatrix(Matrix m, double[] values)
        {
            for (int i = 0; i < values.GetLength(0); i++)
            {
                double value = values[i];
                int row = (int)Math.Floor((double)i / 4);
                int column = i % 4;
                m.Set(row, column, value);
            }
        }

        [Fact]
        public void testMult()
        {
            double[] m1Values = {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 8, 7, 6, 5, 4, 3, 2
            };

            Matrix m1 = new Matrix(4, 4);
            fillMatrix(m1, m1Values);

            double[] m2Values = {
                -2, 1, 2, 3, 3, 2, 1, -1, 4, 3, 6, 5, 1, 2, 7, 8 
            };

            Matrix m2 = new Matrix(4, 4);
            fillMatrix(m2, m2Values);

            double[] m3Values = {
                20, 22, 50, 48, 44, 54, 114, 108, 40, 58, 110, 102, 16, 26, 46, 42
            };

            Matrix m3 = new Matrix(4, 4);
            fillMatrix(m3, m3Values);

            Assert.Equal(m3, m1 * m2);
        }

        [Fact]
        public void testMultTuple()
        {
            double[] m1Values = {
                1, 2, 3, 4, 2, 4, 4, 2, 8, 6, 4, 1, 0, 0, 0, 1
            };

            Matrix m1 = new Matrix(4, 4);
            fillMatrix(m1, m1Values);

            Tuple<double, double, double, double> tuple = Tuple.Create(1.0, 2.0, 3.0, 1.0);

            double[] m3Values = {
                20, 22, 50, 48, 44, 54, 114, 108, 40, 58, 110, 102, 16, 26, 46, 42
            };

            Tuple<double, double, double, double> result = Tuple.Create(18.0, 24.0, 33.0, 1.0);
            Assert.Equal(result, m1 * tuple);
        }
    }
}

