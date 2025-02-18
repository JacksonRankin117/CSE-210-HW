using System;

class Program{
    static void Main() {
        Circle circle = new Circle();
        Console.WriteLine(circle.SurfaceArea(1));

    }
}

class Circle
{
    public double _pi = 3.141592653589792328;

    public double SurfaceArea(double radius) {
        return radius * _pi;
    }
}