﻿using System;

using Rayzin.Core;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var canvas = new CanvasF(900, 550);
            var env = new Environment(new Vector3D(0, -0.1, 0), new Vector3D(-0.01, 0, 0));
            var p = new Projectile(new Point3D(0, 1, 0), new Vector3D(1, 1.8, 0).Normalize() * 11.25);

            while (p.Position.Y > 0)
            {
                p = Tick(env, p);

                int x = (int)(p.Position.X);
                int y = canvas.Height - (int)(p.Position.Y);

                canvas[x, y] = new ColorF(1, 0, 0);
            }

            canvas.SaveToPpm(@"D:\temp\test.ppm");
        }

        private static Projectile Tick(Environment env, Projectile proj)
        {
            Point3D position = proj.Position + proj.Velocity;
            Vector3D velocity = proj.Velocity + env.Gravity + env.Wind;
            return new Projectile(position, velocity);
        }
    }
}