using System;

public class Color : Vec3
{
    public Color(double r, double g, double b) : base(r, g, b) { }

    public void WriteColor(StreamWriter writer)
    {
        double r = this.X;
        double g = this.Y;
        double b = this.Z;

        // Convert to byte range [0,255]
        int rByte = (int)(255.999 * r);
        int gByte = (int)(255.999 * g);
        int bByte = (int)(255.999 * b);

        // Output color values
        writer.WriteLine($"{rByte} {gByte} {bByte}");
    }
}
