using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        HittableList world = new HittableList();

        Lambertian groundMaterial = new Lambertian(new Color(0, 0.6, 0));
        world.Add(new Sphere(new Vec3(0, -1000, 0), 1000, groundMaterial));

        // Adds a random scattering of spheres.
        // There will be a mix of diffuse, metal, and glass spheres.
        int sphereLimit = 11;
        Random rand = new Random();

        for (int a = -sphereLimit; a < sphereLimit; a++)
        {
            for (int b = -sphereLimit; b < sphereLimit; b++)
            {
                double chooseMat = rand.NextDouble();
                Vec3 center = new Vec3(
                    a + 0.9 * rand.NextDouble(),
                    0.2,
                    b + 0.9 * rand.NextDouble()
                );

                if ((center - new Vec3(4, 0.2, 0)).Length > 0.33)
                {
                    Material sphereMaterial;

                    if (chooseMat < 0.33)
                    {
                        // Diffuse
                        Color albedo = Vec3.Random() * Vec3.Random();
                        sphereMaterial = new Lambertian(albedo);
                        world.Add(new Sphere(center, 0.2, sphereMaterial));
                    }
                    else if (chooseMat < 0.66)
                    {
                        // Metal
                        Color albedo = Vec3.Random(0.5, 1);
                        double fuzz = rand.NextDouble() * 0.5;
                        sphereMaterial = new Metal(albedo, fuzz);
                        world.Add(new Sphere(center, 0.2, sphereMaterial));
                    }
                    else
                    {
                        // Glass
                        sphereMaterial = new Dielectric(1.5);
                        world.Add(new Sphere(center, 0.2, sphereMaterial));
                    }
                }
            }
        }

        // Large glass sphere
        Dielectric material1 = new Dielectric(1.5);
        world.Add(new Sphere(new Vec3(0, 1, -3), 1.0, material1));

        // Large matte sphere
        Lambertian material2 = new Lambertian(new Color(0.4, 0.2, 0.1));
        world.Add(new Sphere(new Vec3(0, 1, 0), 1.0, material2));

        // Large metal sphere
        Metal material3 = new Metal(new Color(0.7, 0.6, 0.5), 0.0);
        world.Add(new Sphere(new Vec3(0, 1, 3), 1.0, material3));

        Camera cam = new Camera
        {
            AspectRatio = 16.0 / 9.0,
            ImageWidth = 1200,
            SamplesPerPixel = 10,
            MaxDepth = 20,

            Vfov = 20,
            LookFrom = new Vec3(13, 2, -4),
            LookAt = new Vec3(0, 0, 0),
            Vup = new Vec3(0, 1, 0),

            DefocusAngle = 0.6,
            FocusDist = 10.0
        };

        cam.Render(world);
    }
}
