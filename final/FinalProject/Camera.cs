using System;

public class Camera {
    public double AspectRatio { get; set; } = 1.0;  // Ratio of image width over height
    public int ImageWidth { get; set; } = 100;  // Rendered image width in pixel count
    public int SamplesPerPixel { get; set; } = 10;   // Count of random samples for each pixel
    public int MaxDepth { get; set; } = 10;   // Maximum number of ray bounces into scene

    public double Vfov { get; set; } = 90;  // Vertical field of view
    public Vec3 LookFrom { get; set; } = new Vec3(0, 0, 0);
    public Vec3 LookAt { get; set; } = new Vec3(0, 0, -1);
    public Vec3 Vup { get; set; } = new Vec3(0, 1, 0);

    public double DefocusAngle { get; set; } = 0;
    public double FocusDist { get; set; } = 10;

    private int ImageHeight;
    private double pixelSamplesScale;
    private Vec3 center;
    private Vec3 pixel00Loc;
    private Vec3 pixelDeltaU;
    private Vec3 pixelDeltaV;
    private Vec3 u, v, w;
    private Vec3 defocusDiskU;
    private Vec3 defocusDiskV;

    public void Render(Hittable world, string filename) {
        Initialize();

        using (StreamWriter writer = new StreamWriter(filename)) {
            writer.WriteLine($"P3\n{ImageWidth} {ImageHeight}\n255");

            for (int j = 0; j < ImageHeight; j++) {
                Console.Error.Write($"\rScanlines remaining: {ImageHeight - j} ");
                for (int i = 0; i < ImageWidth; i++) {
                    Color pixelColor = new Color(0, 0, 0);
                    for (int sample = 0; sample < SamplesPerPixel; sample++) {
                        Ray r = GetRay(i, j);
                        pixelColor += RayColor(r, MaxDepth, world);
                    }

                    // Scale the color by the number of samples per pixel
                    Color finalColor = pixelSamplesScale * pixelColor;

                    // Write color to file
                    Color.WriteColor(writer, finalColor);
                }
            }
        }
        Console.Error.WriteLine("\rDone.                     ");
    }

    private void Initialize() {

        ImageHeight = (int)(ImageWidth / AspectRatio);
        ImageHeight = Math.Max(ImageHeight, 1);
        pixelSamplesScale = 1.0 / SamplesPerPixel;
        center = LookFrom;

        double theta = DegreesToRadians(Vfov);
        double h = Math.Tan(theta / 2);
        double viewportHeight = 2 * h * FocusDist;
        double viewportWidth = viewportHeight * ((double)ImageWidth / ImageHeight);

        w = Vec3.UnitVector(LookFrom - LookAt);
        u = Vec3.UnitVector(Vec3.Cross(Vup, w));
        v = Vec3.Cross(w, u);

        Vec3 viewportU = viewportWidth * u;
        Vec3 viewportV = viewportHeight * -v;

        pixelDeltaU = viewportU / ImageWidth;
        pixelDeltaV = viewportV / ImageHeight;

        Vec3 viewportUpperLeft = center - (FocusDist * w) - viewportU / 2 - viewportV / 2;
        pixel00Loc = viewportUpperLeft + 0.5 * (pixelDeltaU + pixelDeltaV);

        double defocusRadius = FocusDist * Math.Tan(DegreesToRadians(DefocusAngle / 2));
        defocusDiskU = u * defocusRadius;
        defocusDiskV = v * defocusRadius;
    }


    private Ray GetRay(int i, int j) {

        Vec3 offset = SampleSquare();
        Vec3 pixelSample = pixel00Loc + ((i + offset.X) * pixelDeltaU) + ((j + offset.Y) * pixelDeltaV);
        Vec3 rayOrigin = (DefocusAngle <= 0) ? center : DefocusDiskSample();
        Vec3 rayDirection = pixelSample - rayOrigin;

        return new Ray(rayOrigin, rayDirection);
    }

    private Vec3 SampleSquare() {

        Vec3 offset = new Vec3(RandomDouble() - 0.5, RandomDouble() - 0.5, 0);

        return offset;
    }

    private Vec3 DefocusDiskSample() {
        Vec3 p = RandomInUnitDisk();

        return center + (p.X * defocusDiskU) + (p.Y * defocusDiskV);
    }


    private Color RayColor(Ray r, int depth, Hittable world) {
        if (depth <= 0) return new Color(0, 0, 0);

        HitRecord rec;

        if (world.Hit(r, new Interval(0.001, double.PositiveInfinity), out rec)) {

            Ray scattered;
            Color attenuation;

            if (rec.Mat.Scatter(r, rec, out attenuation, out scattered)) {
                return attenuation * RayColor(scattered, depth - 1, world);
            }
            return new Color(0, 0, 0);
        }
    
        Vec3 unitDirection = Vec3.UnitVector(r.Direction);
        double a = 0.5 * (unitDirection.Y + 1.0);
        Color backgroundColor = (1.0 - a) * new Color(1.0, 1.0, 1.0) + a * new Color(0.5, 0.7, 1.0);

        return backgroundColor;
    }



    private double DegreesToRadians(double degrees) {
        return degrees * (Math.PI / 180.0);
    }
    

    private double RandomDouble() {
        Random rand = new Random();
        double randomValue = rand.NextDouble();

        return randomValue;
    }

    private Vec3 RandomInUnitDisk() {

        Random rand = new Random();

        while (true) {

            Vec3 p = new Vec3(rand.NextDouble() * 2 - 1, rand.NextDouble() * 2 - 1, 0);
            
            if (p.LengthSquared() < 1) {
                return p;
            }
        }
    }
}
