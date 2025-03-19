using System.IO;

namespace FinalProject
{
    public class Color
    {
        public Color(double r, double g, double b) : base(r, g, b) { }

        public void WriteColor(StreamWriter writer)
        {
            int rByte = (int)(255.999 * X);
            int gByte = (int)(255.999 * Y);
            int bByte = (int)(255.999 * Z);
            writer.WriteLine($"{rByte} {gByte} {bByte}");
        }
    }
}
