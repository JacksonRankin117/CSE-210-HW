class Program
{
    static void Main()
    {
        HittableList world = new HittableList();
        Random rand = new Random();

        /*************** Adds a large number of small spheres ****************/
        // Matte Grass-green sphere. This acts as the ground.
        world.Add(new Sphere(new Vec3(0, -1000, 0), 1000, new Lambertian(new Color(0.3, 0.3, 0.3))));

        /********** Adds Three Large Spheres of different materials **********/
        // Lambertian sphere
        world.Add(new Sphere(new Vec3(0, 1, 0), 1, new Lambertian(new Color(0.8, 0.3, 0.3))));

        // Metal sphere
        world.Add(new Sphere(new Vec3(0, 1, -3), 1, new Metal(new Color(0.5, 0.5, 0.5), 0.0)));

        // Dielectric sphere
        world.Add(new Sphere(new Vec3(0, 1, 3), 1, new Dielectric(1.5)));

        /*************** Adds a large number of small spheres ****************/

        int lim = 12;

        for (int a = -lim; a < lim; a++)
        {
            for (int b = -lim; b < lim; b++)
            {   
                double chooseMat = rand.NextDouble();
                Vec3 center = new Vec3(a + 0.9 * rand.NextDouble(), 0.2, b + 0.9 * rand.NextDouble());

                if ((center - new Vec3(4, 0.2, 0)).Length() > 0.9)
                {
                    if (chooseMat < 0.33)
                    {
                        // Lambertian spheres
                        world.Add(new Sphere(center, 0.2, new Lambertian(Color.Random())));
                    }
                    else if (chooseMat < 0.66)
                    {
                        // Metal spheres 
                        world.Add(new Sphere(center, 0.2, new Metal(Color.Random(), 0.0)));
                    }
                    else
                    {
                        // Dielectric spheres
                        world.Add(new Sphere(center, 0.2, new Dielectric(1.5)));
                    }
                }
            }
        }

        // Camera setup
        Camera cam = new Camera
        {
            AspectRatio     = 21.0 / 9.0,
            ImageWidth      = 5040,
            SamplesPerPixel = 20,
            MaxDepth        = 50,
            Vfov            = 20,
            LookFrom        = new Vec3(13, 2, -4),
            LookAt          = new Vec3(0, 0.5, 0),
            Vup             = new Vec3(0, 1, 0),
            DefocusAngle    = 0.6,
            FocusDist       = 10
        };

        // Render the scene and save to file
        cam.Render(world, "tracer_bad.ppm");
    }
}
