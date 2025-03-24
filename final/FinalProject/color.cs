using System.IO;

namespace FinalProject
{
    public class Color
    {
        public double X { get; set; }  // Red component
        public double Y { get; set; }  // Green component
        public double Z { get; set; }  // Blue component

        public Color(double r, double g, double b)
        {
            X = r;
            Y = g;
            Z = b;
        }

        public void WriteColor(StreamWriter writer)
        {
            int rByte = (int)(255.999 * X);
            int gByte = (int)(255.999 * Y);
            int bByte = (int)(255.999 * Z);
            writer.WriteLine($"{rByte} {gByte} {bByte}");
        }
    }
}
