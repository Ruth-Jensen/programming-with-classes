using System;

class Program
{
    static void Main(string[] args)
    {
        // 1
        // 5
        // 3/4
        // 1/3

        Fraction fraction = new Fraction();

        string fractionString = fraction.GetFractionString();
        double fractionDouble = fraction.GetDecimalValue();
        Console.WriteLine(fractionString);
        Console.WriteLine(fractionDouble);

        fraction.SetTop(5);
        fractionString = fraction.GetFractionString();
        fractionDouble = fraction.GetDecimalValue();
        Console.WriteLine(fractionString);
        Console.WriteLine(fractionDouble);

        fraction.SetTop(3);
        fraction.SetBottom(4);
        fractionString = fraction.GetFractionString();
        fractionDouble = fraction.GetDecimalValue();
        Console.WriteLine(fractionString);
        Console.WriteLine(fractionDouble);

        fraction.SetTop(1);
        fraction.SetBottom(3);
        fractionString = fraction.GetFractionString();
        fractionDouble = fraction.GetDecimalValue();
        Console.WriteLine(fractionString);
        Console.WriteLine(fractionDouble);
    }
}