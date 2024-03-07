import math;
public class Circle : Shape
{
    private double _radius;
    public Circle (double radius)
    {
        _radius = radius;
    }
    public override double GetArea()
    {
        return math.pi * _radius ** 2;
    }
}