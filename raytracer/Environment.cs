using System;
namespace raytracer
{
	public class Environment
	{
        private RayTuple gravity;
        private RayTuple wind;

        public RayTuple Gravity => gravity;
        public RayTuple Wind => wind;

        public Environment(RayTuple gravity, RayTuple wind)
        {
            this.gravity = gravity;
            this.wind = wind;
        }
    }
}

