public abstract class Shape
{
    private string _color;
    private string _type;

    public Shape(string color, string type = "Shape")
    { 
        _color = color;
        _type = type;
    }
    public string GetColor() { return _color; }
    public void SetColor(string color) { _color = color; }
    public string GetType() { return _type; }
    public void SetType(string type) { _type = type; }
    public abstract double GetArea();

}