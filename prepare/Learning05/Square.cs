using System;

public class Square : Shape
{   
    // Creates a variable to store the sqwuares only notable dimension
    private double _side;

    // Square method. Gets all important info about a rectangle shape
    public Square(string color, double side) : base (color)
    {
        _side = side;
    }

    // Uses the same method name, but changes the method to return a mathematically correct area
    public override double GetArea()
    {
        return _side * _side;
    }
}