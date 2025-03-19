using System;
using System.IO;

public static class ColorUtil
{
    public static void WriteColor(StreamWriter writer, Vec3 color)
    {
        int r = (int)(255.999 * color.X);
        int g = (int)(255.999 * color.Y);
        int b = (int)(255.999 * color.Z);
        
        writer.WriteLine($"{r} {g} {b}");
    }
}
