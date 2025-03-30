using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        HittableList world = new HittableList();

        // Large matte sphere
        Lambertian material2 = new Lambertian(new Color(0.0, 0.0, 0.0));
        world.Add(new Sphere(new Vec3(0, 1, 0), 1.0, material2));

        Camera cam = new Camera
        {
            AspectRatio = 16.0 / 9.0,
            ImageWidth = 50,
            SamplesPerPixel = 10,
            MaxDepth = 20,

            Vfov = 20,
            LookFrom = new Vec3(13, 2, -4),
            LookAt = new Vec3(0, 1, 0),
            Vup = new Vec3(0, 1, 0),

            DefocusAngle = 0.6,
            FocusDist = 10.0
        };

        cam.Render(world, "tracer.ppm");
    }
}
