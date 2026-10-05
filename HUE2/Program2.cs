using System;
using System.Security.Cryptography;
public class Auto
{
    private string farbe;
    private string kennzeichen;
    private double preis;
    private int baujahr;

    public string Farbe
    {
        get { return farbe; }
        set { farbe = value; }
    }
    public string Kennzeichen
    {
        get { return kennzeichen; }
        set { kennzeichen = value; }
    }
    public double Preis
    {
        get { return preis; }
        set { preis = value; }
    }
    public int Baujahr
    {
        get { return baujahr; }
        set { baujahr = value; }
    }

    public Auto()
    {
        farbe = "Rot";
        kennzeichen = "W-1234";
        preis = 10000;
        baujahr = 2020;
    }

    public Auto(string Farbe, string Kennzeichen)
    {
        this.farbe = Farbe;
        this.kennzeichen = Kennzeichen;
    }

    public Auto(string Farbe, string Kennzeichen, double Preis, int Baujahr)
    {
        this.farbe = Farbe;
        this.kennzeichen = Kennzeichen;
        this.preis = Preis;
        this.baujahr = Baujahr;
    }

    public void ZeigeAuto()
    {
        Console.WriteLine($"\nFarbe: {Farbe}");
        Console.WriteLine($"Kennzeichen: {Kennzeichen}");
        Console.WriteLine($"Preis: {Preis}");
        Console.WriteLine($"Baujahr: {Baujahr}");
    }
}

public class Program2
{
    public static void Main()
    {
        Auto auto = new Auto("Rot", "w-1234", 10000, 2017); //Objekte anlegen
        Auto auto2 = new Auto("Blau", "W-5678", 20000, 2021);

        auto.ZeigeAuto();
        auto2.ZeigeAuto();
    }
}
