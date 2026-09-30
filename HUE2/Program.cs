using System;
using System.Security.Cryptography;
public class Punkt
{
    private int x;
    private int y;

    public int X
    {
        get { return x; }
        set { x = value; }
    }
    public int Y
    {
        get { return y; }
        set { y = value; }
    }

    public Punkt()
    {
        x = 0;
        y = 0;
    }
}

public class Gerade
{
    private Punkt p1;
    private Punkt p2;

    public Gerade(Punkt p1, Punkt p2)
    {
        this.p1 = p1;
        this.p2 = p2;
    }

    public double BerechneLaenge()
    {
        double differenzX = p2.X - p1.X;
        double differenzY = p2.Y - p1.Y;
        return Math.Sqrt(differenzX * differenzX + differenzY * differenzY); //Pythagoras
    }
}

public class Program
{
    public static void Main()
    {
        Punkt p1 = new Punkt();
        Punkt p2 = new Punkt();
        p1.X = 0;
        p1.Y = 0;
        p2.X = 3;
        p2.Y = 4;

        Gerade gerade = new Gerade(p1, p2);
        Console.WriteLine($"Länge der Geraden: {gerade.BerechneLaenge()}");
    }
}