using System;
namespace raytracer
{
	public class Projectile
	{
        private readonly RayTuple position;
        private readonly RayTuple velocity;

        public RayTuple Position => position;
        public RayTuple Velocity => velocity;

        public Projectile(RayTuple position, RayTuple velocity)
		{
			this.position = position;
			this.velocity = velocity;
		}
	}
}

