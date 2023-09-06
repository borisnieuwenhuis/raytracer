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
            Assert.Equal(7, result.x);
            Assert.Equal(8, result.y);
            Assert.Equal(10, result.z);
            Assert.Equal(12, tuple3.w);
        }
    }
}

