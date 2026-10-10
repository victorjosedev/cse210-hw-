using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Polymorphic List: Holds different derived types under the base type 'Shape'
        List<Shape> shapes = new List<Shape>();

        // Adding Square, Rectangle, and Circle to the same list
        shapes.Add(new Square("Red", 5));
        shapes.Add(new Rectangle("Blue", 4, 6));
        shapes.Add(new Circle("Green", 3));

        Console.WriteLine("=================================================");
        Console.WriteLine("           POLYMORPHISM IN ACTION: SHAPES        ");
        Console.WriteLine("=================================================");
        Console.WriteLine();

        // Single loop calling GetColor() and GetArea() polymorphically
        foreach (Shape shape in shapes)
        {
            string color = shape.GetColor();
            double area = shape.GetArea();

            Console.WriteLine($"Shape Color: {color} | Area: {area:F2}");
        }

        Console.WriteLine();
        Console.WriteLine("=================================================");
    }
}