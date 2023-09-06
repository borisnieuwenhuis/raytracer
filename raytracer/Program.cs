// See https://aka.ms/new-console-template for more information
using System;
using raytracer;

Console.WriteLine("There we go again!");
RayTuple point = RayTuple.createPoint(1, 1, 0);
RayTuple velocity = RayTuple.createVector(1, 1, 0);
Projectile p = new Projectile(point, velocity);

RayTuple gravity = RayTuple.createVector(0, -0.1, 0);
RayTuple wind = RayTuple.createVector(-0.01, 0, 0);
raytracer.Environment environment = new raytracer.Environment(gravity, wind);

int i = 0;
Console.WriteLine(String.Format("After tick {0}, position {1}", i, p.Position));

while (p.Position.Y > 0) {
    p = tick(environment, p);
    Console.WriteLine(String.Format("After tick {0}, position {1}", i, p.Position));
    i++;
}

Projectile tick(raytracer.Environment env, Projectile projectile)
{
    RayTuple newPosition = projectile.Position + projectile.Velocity;
    RayTuple newVelocity = projectile.Velocity + env.Gravity + env.Wind;
    return new Projectile(newPosition, newVelocity);
}