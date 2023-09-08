// See https://aka.ms/new-console-template for more information
using System;
using System.Drawing;
using raytracer;

Console.WriteLine("There we go again!");
RayTuple startPoint = RayTuple.createPoint(0, 1, 0);
RayTuple startVelocity = 11.25 * RayTuple.createVector(1, 1.8, 0).normalize();
Projectile p = new Projectile(startPoint, startVelocity);

RayTuple gravity = RayTuple.createVector(0, -0.1, 0);
RayTuple wind = RayTuple.createVector(-0.01, 0, 0);
raytracer.Environment environment = new raytracer.Environment(gravity, wind);

int i = 0;
Console.WriteLine(String.Format("After tick {0}, position {1}", i, p.Position));

Canvas c = new Canvas(900, 550);
while (p.Position.Y > 0 && p.Position.Y < c.Height) {
    p = tick(environment, p);
    c.writePixel((int)p.Position.X, (int)c.Height - (int)p.Position.Y, new raytracer.Color(0, 255, 0));
    i++;
}

PPM ppm = new PPM(c);
String fileName = "/Users/boris/Projects/raytracer/trajectory.ppm";
ppm.writeFile(fileName);
Console.WriteLine(String.Format("generated image file at {0}", fileName));

Projectile tick(raytracer.Environment env, Projectile projectile)
{
    RayTuple newPosition = projectile.Position + projectile.Velocity;
    RayTuple newVelocity = projectile.Velocity + env.Gravity + env.Wind;
    return new Projectile(newPosition, newVelocity);
}