using System;
namespace raytracer.Tests
{
	public class RayTupleTest
	{
        [Fact]
        public void TestAdd()
        {
            RayTuple point= RayTuple.createPoint(1, 2, 3);
            RayTuple vector = RayTuple.createVector(1, 2, 3);
            RayTuple result = point + vector;
            Assert.Equal(2, result.X);
            Assert.Equal(4, result.Y);
            Assert.Equal(6, result.Z);
            Assert.Equal(RayTuple.Vector, result.W);
        }

        [Fact]
        public void TestSubtract()
        {
            RayTuple point1 = RayTuple.createPoint(3, 2, 1);
            RayTuple point2 = RayTuple.createPoint(5, 6, 7);
            RayTuple result = point1 - point2;
            Assert.Equal(-2, result.X);
            Assert.Equal(-4, result.Y);
            Assert.Equal(-6, result.Z);
            Assert.Equal(RayTuple.Vector, result.W);
        }
    }
}

