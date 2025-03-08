using System;

public class Circle : Shape
{   
    // Holds the least important dimension of a circle, the radius
    private double _radius;


    public Circle(string color, double radius) : base (color)
    {
        _radius = radius;
    }

    // Calculates and stores the area of the circle
    public override double GetArea()
    {
        return _radius * _radius * Math.PI;
    }
}