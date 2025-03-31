using System;

class Program
{
    static void Main()
    {
        HittableList world = new HittableList();
        world.Add(new Sphere(new Vec3(0, 1000, 0), 1000, new Lambertian(new Color(0.5, 1.0, 0.1))));
        world.Add(new Sphere(new Vec3(0, -1000, 0), 1000, new Lambertian(new Color(1.0, 0.0, 1.0))));



        // Camera setup
        Camera cam = new Camera
        {
            AspectRatio = 16.0 / 9.0,
            ImageWidth = 400,
            SamplesPerPixel = 10,
            MaxDepth = 20,
            Vfov = 45,
            LookFrom = new Vec3(0, 0, 10),
            LookAt = new Vec3(0, 0, 0),   // Look directly at the sphere
            Vup = new Vec3(0, 1, 0),
            DefocusAngle = 0.6,
            FocusDist = 10.0
        };

        // Render the scene and save to file
        cam.Render(world, "tracer.ppm");
    }
}
