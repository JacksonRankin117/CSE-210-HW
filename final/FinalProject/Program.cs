using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Image settings
        double aspectRatio = 16.0 / 9.0;
        int imageWidth = 400;

        // Calculate image height and ensure it's at least 1
        int imageHeight = (int)(imageWidth / aspectRatio);
        imageHeight = (imageHeight < 1) ? 1 : imageHeight;

        // Camera settings
        double focalLength = 1.0;
        double viewportHeight = 2.0;
        double viewportWidth = viewportHeight * ((double)imageWidth / imageHeight);
        point3 cameraCenter = new point3(0, 0, 0);

        // Calculate viewport vectors
        Vec3 viewportU = new Vec3(viewportWidth, 0, 0);
        Vec3 viewportV = new Vec3(0, -viewportHeight, 0);

        // Pixel delta calculations
        Vec3 pixelDeltaU = viewportU / imageWidth;
        Vec3 pixelDeltaV = viewportV / imageHeight;

        // Compute upper-left pixel location
        point3 viewportUpperLeft = cameraCenter - new Vec3(0, 0, focalLength) - viewportU / 2 - viewportV / 2;
        point3 pixel00Loc = viewportUpperLeft + 0.5 * (pixelDeltaU + pixelDeltaV);

        // Output file path
        string filePath = "/Users/jacksonrankin/Desktop/Student/Four/CSE 210/CSE-210-HW/final/FinalProject/output.ppm";

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            // Write PPM header
            writer.WriteLine($"P3\n{imageWidth} {imageHeight}\n255");

            // Render loop
            for (int j = 0; j < imageHeight; j++)
            {
                Console.Write($"\rScanlines remaining: {imageHeight - j} ");
                Console.Out.Flush();

                for (int i = 0; i < imageWidth; i++)
                {
                    point3 pixelCenter = pixel00Loc + (i * pixelDeltaU) + (j * pixelDeltaV);
                    Vec3 rayDirection = pixelCenter - cameraCenter;
                    Ray r = new Ray(cameraCenter, rayDirection);

                    Color pixelColor = RayColor(r);
                    pixelColor.WriteColor(writer);
                }
            }
        }

        Console.WriteLine("\nDone.");
    }

    static Color RayColor(Ray r)
    {
        Vec3 unitDirection = Vec3.UnitVector(r.Direction);
        double a = 0.5 * (unitDirection.Y + 1.0);
        return (1.0 - a) * new Color(1.0, 1.0, 1.0) + a * new Color(0.5, 0.7, 1.0);
    }
}

// Ensure this file knows about Vec3 where point3 is defined
using point3 = Vec3;
