using System;

public class Camera {
    public double _aspect_ratio { get; set; } = 1.0;  // Ratio of image width over height
    public int _image_width { get; set; } = 100;  // Rendered image width in pixel count
    public int _samples_per_pixel { get; set; } = 10;   // Count of random samples for each pixel
    public int _max_depth { get; set; } = 10;   // Maximum number of ray bounces into scene

    public double _vert_fov { get; set; } = 90;  // Vertical field of view
    public Vec3 _look_from { get; set; } = new Vec3(0, 0, 0);
    public Vec3 _look_at { get; set; } = new Vec3(0, 0, -1);
    public Vec3 _vert_up { get; set; } = new Vec3(0, 1, 0);

    public double _defocus_angle { get; set; } = 0;
    public double _focus_dist { get; set; } = 10;

    private int _image_height;
    private double _pixel_samples_scale;
    private static Random _rand = new Random();
    private Vec3 _center;
    private Vec3 _pixel00_loc;
    private Vec3 _pixel_delta_u;
    private Vec3 _pixel_delta_v;
    private Vec3 _u, _v, _w;
    private Vec3 _defocus_disk_u;
    private Vec3 _defocus_disk_v;

    public void Render(Hittable world, string filename) {
        Initialize();

        using (StreamWriter writer = new StreamWriter(filename)) {
            writer.WriteLine($"P3\n{_image_width} {_image_height}\n255");

            for (int j = 0; j < _image_height; j++) {
                Console.Error.Write($"\rProgress: {100*(j)/_image_height}% - Scanline {j} of {_image_height} ");
                
                for (int i = 0; i < _image_width; i++) {
                    Color pixelColor = new Color(0, 0, 0);
                    for (int sample = 0; sample < _samples_per_pixel; sample++) {
                        Ray r = GetRay(i, j);
                        pixelColor += RayColor(r, _max_depth, world);
                    }

                    // Scale the color by the number of samples per pixel
                    Color finalColor = _pixel_samples_scale * pixelColor;

                    // Write color to file
                    Color.WriteColor(writer, finalColor);
                }
            }
        }
        Console.Error.WriteLine("\rDone.                                    ");
    }

    private void Initialize() {

        _image_height = (int)(_image_width / _aspect_ratio);
        _image_height = Math.Max(_image_height, 1);
        _pixel_samples_scale = 1.0 / _samples_per_pixel;
        _center = _look_from;

        double theta = DegreesToRadians(_vert_fov);
        double h = Math.Tan(theta / 2);
        double viewportHeight = 2 * h * _focus_dist;
        double viewportWidth = viewportHeight * ((double)_image_width / _image_height);

        _w = Vec3.UnitVector(_look_from - _look_at);
        _u = Vec3.UnitVector(Vec3.Cross(_vert_up, _w));
        _v = Vec3.Cross(_w, _u);

        Vec3 viewportU = viewportWidth * _u;
        Vec3 viewportV = viewportHeight * -_v;

        _pixel_delta_u = viewportU / _image_width;
        _pixel_delta_v = viewportV / _image_height;

        Vec3 viewportUpperLeft = _center - (_focus_dist * _w) - viewportU / 2 - viewportV / 2;
        _pixel00_loc = viewportUpperLeft + 0.5 * (_pixel_delta_u + _pixel_delta_v);

        double defocusRadius = _focus_dist * Math.Tan(DegreesToRadians(_defocus_angle / 2));
        _defocus_disk_u = _u * defocusRadius;
        _defocus_disk_v = _v * defocusRadius;
    }


    private Ray GetRay(int i, int j) {
        Vec3 offset = SampleSquare();
        Vec3 pixelSample = _pixel00_loc + ((i + offset._x) * _pixel_delta_u) + ((j + offset._y) * _pixel_delta_v);
        Vec3 rayOrigin = (_defocus_angle <= 0) ? _center : DefocusDiskSample();
        Vec3 rayDirection = pixelSample - rayOrigin;

        return new Ray(rayOrigin, rayDirection);
    }



    private Vec3 SampleSquare() {

        return new Vec3(RandomDouble() - 0.5, RandomDouble() - 0.5, 0);
    }

    private Vec3 DefocusDiskSample() {
        
        Vec3 p = RandomInUnitDisk();

        return _center + (p._x * _defocus_disk_u) + (p._y * _defocus_disk_v);
    }


    private Color RayColor(Ray r, int depth, Hittable world) {
        if (depth <= 0) return new Color(0, 0, 0);

        HitRecord rec;

        if (world.Hit(r, new Interval(0.001, double.PositiveInfinity), out rec)) {

            Ray scattered;
            Color attenuation;

            if (rec._mat.Scatter(r, rec, out attenuation, out scattered)) {
                return attenuation * RayColor(scattered, depth - 1, world);
            }
            return new Color(0, 0, 0);
        }
    
        Vec3 unitDirection = Vec3.UnitVector(r.Direction);
        double a = 0.5 * (unitDirection._y + 1.0);
        Color backgroundColor = (1.0 - a) * new Color(1.0, 1.0, 1.0) + a * new Color(0.5, 0.7, 1.0);

        return backgroundColor;
    }

    private double DegreesToRadians(double degrees) {
        return degrees * (Math.PI / 180.0);
    }
    

    private double RandomDouble() {
        double randomValue = _rand.NextDouble();

        return randomValue;
    }

    private Vec3 RandomInUnitDisk() {

        while (true) {

            Vec3 p = new Vec3(_rand.NextDouble() * 2 - 1, _rand.NextDouble() * 2 - 1, 0);
            
            if (p.LengthSquared() < 1) {
                return p;
            }
        }
    }
}
