namespace OopExample;

interface IHasPerimeter
{
    public float GetPerimeter();
}

interface IHasArea
{
    public float GetArea();
}

interface IHasNumberOfSides
{
    public int GetNumberOfSides();
}

interface IHasDiameter
{
    public float GetDiameter();
}

interface IShape : IHasPerimeter, IHasArea, IHasNumberOfSides
{ }

class Square : IShape
{
    public float sideLength;

    public Square(float sideLength)
    {
        this.sideLength = sideLength;
    }

    public float GetPerimeter()
    {
        return sideLength * 4;
    }

    public float GetArea()
    {
        return sideLength * sideLength;
    }

    public int GetNumberOfSides()
    {
        return 4;
    }
}

class Circle : IShape, IHasDiameter
{
    public float radius;

    public Circle(float radius)
    {
        this.radius = radius;
    }

    public float GetPerimeter()
    {
        return 2 * radius * MathF.PI;
    }

    public float GetArea()
    {
        return MathF.PI * radius * radius;
    }

    public int GetNumberOfSides()
    {
        return 1;
    }

    public float GetDiameter()
    {
        return 2 * radius;
    }
}

class EquilateralTriangle : IShape
{
    public float sideLength;

    public EquilateralTriangle(float sideLength)
    {
        this.sideLength = sideLength;
    }

    public float GetPerimeter()
    {
        return sideLength * 3;
    }

    public float GetArea()
    {
        return sideLength * sideLength * MathF.Sqrt(3) / 4;
    }

    public int GetNumberOfSides()
    {
        return 3;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<IShape> shapes = new List<IShape>
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
