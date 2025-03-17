using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Image dimensions
        int imageWidth = 256;
        int imageHeight = 256;

        // File path
        string filePath = "/Users/jacksonrankin/Desktop/Student/Four/CSE 210/CSE-210-HW/final/FinalProject/output.ppm";

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            // Write header
            writer.WriteLine($"P3\n{imageWidth} {imageHeight}\n255");

            for (int j = 0; j < imageHeight; j++)
            {
                // Basically, a loading bar
                Console.WriteLine($"\rScanlines remaining: {imageHeight - j}");
                Console.Out.Flush();

                for (int i = 0; i < imageWidth; i++)
                {
                    var pixelColor = Color((double)i / (imageWidth - 1), (double)j / (imageHeight - 1), 0);
                    pixelColor.WriteColor(writer);
                }
            }
        }

        Console.WriteLine("PPM file written to " + filePath + "\n");
    }

    static Color Color(double r, double g, double b)
    {
        return new Color(r, g, b);
    }
}
