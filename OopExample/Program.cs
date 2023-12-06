using OopExample.Readers;

namespace OopExample;

abstract class Shape
{
    public abstract float GetPerimeter();

    public abstract float GetArea();

    public abstract int GetNumberOfSides();
}

class Square : Shape
{
    public float sideLength;

    public Square(float sideLength)
    {
        this.sideLength = sideLength;
    }

    public override float GetPerimeter()
    {
        return sideLength * 4;
    }

    public override float GetArea()
    {
        return sideLength * sideLength;
    }

    public override int GetNumberOfSides()
    {
        return 4;
    }
}

class Circle : Shape
{
    public float radius;

    public Circle(float radius)
    {
        this.radius = radius;
    }

    public override float GetPerimeter()
    {
        return 2 * radius * MathF.PI;
    }

    public override float GetArea()
    {
        return MathF.PI * radius * radius;
    }

    public override int GetNumberOfSides()
    {
        return 1;
    }

    public float GetDiameter()
    {
        return 2 * radius;
    }
}

class EquilateralTriangle : Shape
{
    public float sideLength;

    public EquilateralTriangle(float sideLength)
    {
        this.sideLength = sideLength;
    }

    public override float GetPerimeter()
    {
        return sideLength * 3;
    }

    public override float GetArea()
    {
        return sideLength * sideLength * MathF.Sqrt(3) / 4;
    }

    public override int GetNumberOfSides()
    {
        return 3;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>
        {
            new Square(4),
            new Circle(2),
            new EquilateralTriangle(7),
            new Square(6),
        };

        foreach (var shape in shapes)
        {
            Console.WriteLine("Shape:");
            Console.WriteLine($"  Perimeter: {shape.GetPerimeter()}");
            Console.WriteLine($"  Area: {shape.GetArea()}");
            Console.WriteLine($"  Number of sides: {shape.GetNumberOfSides()}");
        }
    }
}
