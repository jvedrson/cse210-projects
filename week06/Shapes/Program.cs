using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a list of shapes
        List<Shape> shapes = new List<Shape>();

        Square square = new Square("Yellow", 7);
        shapes.Add(square);

        Rectangle rectangle = new Rectangle("Blue", 5, 3);
        shapes.Add(rectangle);

        Circle circle = new Circle("Red", 4);
        shapes.Add(circle);

        // Iterate through the list and display each shape's color and area.
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Color: {shape.GetColor()}, Area: {shape.GetArea():F2}");
        }
    }
}