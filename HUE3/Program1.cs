using System;

public interface IObjekt3D
{
    double BerechneVolumen();
}

public class Kugel : IObjekt3D
{
    private double radius;

    public Kugel(double radius)
    {
        this.radius = radius;
    }

    public double BerechneVolumen()
    {
        return (4.0 / 3.0) * Math.PI * Math.Pow(radius, 3);
    }
}

public class GeraderZylinder : IObjekt3D
{
    protected double radius;
    protected double hoehe;

    public GeraderZylinder(double radius, double hoehe)
    {
        this.radius = radius;
        this.hoehe = hoehe;
    }

    public virtual double BerechneVolumen()
    {
        return Math.PI * Math.Pow(radius, 2) * hoehe;
    }
}

public class Hohlzylinder : GeraderZylinder
{
    private double radiusInnen;

    public Hohlzylinder(double radius, double hoehe, double radiusInnen)
        : base(radius, hoehe)
    {
        this.radiusInnen = radiusInnen;
    }

    public override double BerechneVolumen()
    {
        return Math.PI * (Math.Pow(radius, 2) - Math.Pow(radiusInnen, 2)) * hoehe;
    }
}

public class Quader : IObjekt3D
{
    private double laenge;
    private double breite;
    private double hoehe;

    public Quader(double laenge, double breite, double hoehe)
    {
        this.laenge = laenge;
        this.breite = breite;
        this.hoehe = hoehe;
    }

    public double BerechneVolumen()
    {
        return laenge * breite * hoehe;
    }
}

public class Program1
{
    public static void Main()
    {
        Kugel kugel = new Kugel(5);
        Quader quader = new Quader(2, 3, 4);
        GeraderZylinder zylinder = new GeraderZylinder(3, 5);
        Hohlzylinder hohlzylinder = new Hohlzylinder(5, 5, 3);
    }
}