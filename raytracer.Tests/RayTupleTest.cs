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
        public void TestSubtractPoints()
        {
            RayTuple point1 = RayTuple.createPoint(3, 2, 1);
            RayTuple point2 = RayTuple.createPoint(5, 6, 7);
            RayTuple result = point1 - point2;
            Assert.Equal(-2, result.X);
            Assert.Equal(-4, result.Y);
            Assert.Equal(-6, result.Z);
            Assert.Equal(RayTuple.Vector, result.W);
        }

        [Fact]
        public void TestSubtractVectorFromPoint()
        {
            RayTuple point = RayTuple.createPoint(3, 2, 1);
            RayTuple vector = RayTuple.createVector(5, 6, 7);
            RayTuple result = point - vector;
            Assert.Equal(-2, result.X);
            Assert.Equal(-4, result.Y);
            Assert.Equal(-6, result.Z);
            Assert.Equal(RayTuple.Point, result.W);
        }

        [Fact]
        public void TestSubtractVectorFromVector()
        {
            RayTuple vector1 = RayTuple.createVector(3, 2, 1);
            RayTuple vector2 = RayTuple.createVector(5, 6, 7);
            RayTuple result = vector1 - vector2;
            Assert.Equal(-2, result.X);
            Assert.Equal(-4, result.Y);
            Assert.Equal(-6, result.Z);
            Assert.Equal(RayTuple.Vector, result.W);
        }

        [Fact]
        public void TestNegateTuple()
        {
            RayTuple vector1 = RayTuple.createVector(3, 2, 1);
            RayTuple result = -vector1;
            Assert.Equal(-3, result.X);
            Assert.Equal(-2, result.Y);
            Assert.Equal(-1, result.Z);
            Assert.Equal(RayTuple.NegPoint, result.W);
        }

        [Fact]
        public void TestMult()
        {
            RayTuple point1 = RayTuple.createPoint(3, 2, 1);
            RayTuple result = 3 * point1;
            Assert.Equal(9, result.X);
            Assert.Equal(6, result.Y);
            Assert.Equal(3, result.Z);
            Assert.Equal(3, result.W);

            result = 0.5 * point1;
            Assert.Equal(1.5, result.X);
            Assert.Equal(1, result.Y);
            Assert.Equal(0.5, result.Z);
            Assert.Equal(0.5, result.W);
        }
    }
}

