public class Square : Shape
{
    private double _side;
    public Square(double side)
    {
        _side = side;
    }
    public override double GetArea()
    {
        return _side ** 2;
    }
}