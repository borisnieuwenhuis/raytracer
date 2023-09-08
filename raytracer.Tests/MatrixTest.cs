using System;
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
    }
}

