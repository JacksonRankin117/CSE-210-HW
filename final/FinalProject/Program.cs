using System;
using System.Diagnostics; // Import for Stopwatch 

/********** Adds Three Large Spheres of different materials **********/
// Lambertian sphere
//_world.Add(new Sphere(new Vec3(0, 1, 0), 1, new Lambertian(new Color(0.8, 0.3, 0.3))));

// Metal sphere
//_world.Add(new Sphere(new Vec3(0, 1, -3), 1, new Metal(new Color(0.5, 0.5, 0.5), 0.0)));

// Dielectric sphere
//_world.Add(new Sphere(new Vec3(0, 1, 3), 1, new Dielectric(1.5)));

/*************** Adds a large number of small spheres ****************/
/*
int _lim = 10;

for (int a = -_lim; a < _lim; a++)
{
    for (int b = -_lim; b < _lim; b++)
    {   
        double chooseMat = _rand.NextDouble();
        Vec3 center = new Vec3(a + 0.9 * _rand.NextDouble(), 0.2, b + 0.9 * _rand.NextDouble());

        if ((center - new Vec3(4, 0.2, 0)).Length() > 0.9)
        {
            if (chooseMat < 0.33)
            {
                // Lambertian spheres
                _world.Add(new Sphere(center, 0.2, new Lambertian(Color.Random())));
            }
            else if (chooseMat < 0.66)
            {
                // Metal spheres 
                _world.Add(new Sphere(center, 0.2, new Metal(Color.Random(), 0.0)));
            }
            else
            {
                // Dielectric spheres
                _world.Add(new Sphere(center, 0.2, new Dielectric(1.5)));
            }
        }
    }
}
*/


class Program
{
    static void Main()
    {
        // Create a new Stopwatch instance to track render time, and start it
        Stopwatch _stopwatch = new Stopwatch();
        _stopwatch.Start();
        
        // Create the scene and world
        HittableList _world = new HittableList();
        Random _rand = new Random();

        // Matte Grass-green sphere. This acts as the ground.
        _world.Add(new Sphere(new Vec3(0, -1000, 0), 1000, new Lambertian(new Color(0.3, 0.5, 0.3))));

        // Moon sphere
        _world.Add(new Sphere(new Vec3(-384, 1, 0), 1.737, new Lambertian(new Color(0.8, 0.0, 1.0))));

        /* 
        VFOV information

        The vertical field of view (VFOV) is the angle that defines how much of
        the scene is visible vertically in the camera's view. Vertical FOV is 
        calculated using the formula:

            FOV = 2*arctan(s/2f)

        where 's' is the size of the film/sensor in the vertical direction, and 'f' is the focal length of the lens.

        For the Mamiya RB67 the VFOV is as follows:
        50mm lens, _vert_fov = 61.9275130641 degrees
        90mm lens, _vert_fov = 36.8698976458 degrees
        180mm lens, _vert_fov = 18.9246444161 degrees
        250mm lens, _vert_fov = 13.6855468253 degrees
        360mm lens, _vert_fov = 9.52728338145 degrees
        500mm lens, _vert_fov = 6.8672607249 degrees

        */

        // Camera setup
        Camera _cam = new Camera
        {
            _aspect_ratio      = 7.0 / 6.0,
            _image_width       = 1000,
            _samples_per_pixel = 5,
            _max_depth         = 5,
            _vert_fov          = 61.9275130641,
            _look_from         = new Vec3(10, 1, 0),
            _look_at           = new Vec3(0, 1, 0),
            _vert_up           = new Vec3(0, 1, 0),
            _defocus_angle     = 0.0,
            _focus_dist        = (new Vec3(10, 2, 0) - new Vec3(0, 1, 0)).Length()
        };

        // Render the scene, and save it to a file
        _cam.Render(_world, "Moon50mm.ppm");

        // Stop the stopwatch after the render is complete, and records the duration
        _stopwatch.Stop();
        TimeSpan ts = _stopwatch.Elapsed;

        // Output the time taken to render
        string _elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
        Console.WriteLine("This render took " + _elapsedTime);
    }
}
