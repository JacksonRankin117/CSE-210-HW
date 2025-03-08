using System;

class Program
{
    static void Main(string[] args)
    {
        // Creates a list of shapes
        List<Shape> shapes = new List<Shape>();

        // Creates and adds a white square with sidelength 4 to the shapes list
        Square square = new Square("White", 4);
        shapes.Add(square);

        // Adds a green rectangle with dimensions 6.3x4.5 to the list
        Rectangle rectangle = new Rectangle("Green", 6.3, 4.5);
        shapes.Add(rectangle);

        // Adds a red circle with a radius of 17 to the list
        Circle circle = new Circle("Red", 17);
        shapes.Add(circle);

        // Iterates therough each element in the list
        foreach (Shape i in shapes)
        {   
            // Gets the color and area of each shape
            string color = i.GetColor();
            double area = i.GetArea();

            Console.WriteLine($"{color}: {area} units^2");
        }
    }
}