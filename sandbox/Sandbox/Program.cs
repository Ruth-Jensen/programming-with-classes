using System;

class Program
{
    static void Main(string[] args)
    {
        Square square = new Square("red", 3);
        Rectangle rectangle = new Rectangle("blue", 4, 5);
        Circle circle = new Circle("green", 6);

        List<Shape> shapes = new List<Shape>{square, rectangle, circle};

        foreach (Shape shape in shapes){

            Console.WriteLine($"The {shape.GetColor()} {shape.GetType()} has an area of {shape.GetArea()}.");
        }

    }
}








// dotnet new console -o name
// cd name
// code .