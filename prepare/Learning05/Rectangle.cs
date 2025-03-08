using System;

public class Rectangle : Shape
{
    // All pertinant rectangle attributes
    private double _length;
    private double _width;

    // Rectangle method to get all the variables.
    public Rectangle(string color, double length, double width) : base (color)
    {
        _length = length;
        _width = width;
    }

    // Overrides the GetArea method from the shape class to return the correct area
    public override double GetArea()
    {
        return _length * _width;
    }
}