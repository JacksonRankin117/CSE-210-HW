using System;

public abstract class Shape
{   
    // String that stores the color of the shape
    private string _color;

    // Creates the shape method
    public Shape(string color)
    {
        _color = color;
    }

    // Gets the color
    public string GetColor()
    {
        return _color;
    }

    // Sets the color
    public void SetColor(string color)
    {
        _color = color;
    }

    // Creates a method that will be overriden by each class, cause area is meaningless in this class
    public abstract double GetArea();
}