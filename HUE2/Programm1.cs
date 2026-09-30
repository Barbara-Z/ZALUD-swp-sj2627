using System;
using System.Security.Cryptography;
public class Segelschiff
{
    private int anzahlMasten;
    private int crewMitglieder;

    public int AnzahlMasten
    {
        get { return anzahlMasten; }
        set { anzahlMasten = value; }
    }
    public int CrewMitglieder
    {
        get { return crewMitglieder; }
        set { crewMitglieder = value; }
    }

    public Segelschiff(int AnzahlMasten, int CrewMitglieder)
    {
        this.anzahlMasten = AnzahlMasten;
        this.crewMitglieder = CrewMitglieder;
    }

    public void ZeigeSegelschiff()
    {
        Console.WriteLine($"\nAnzahl Masten: {AnzahlMasten}");
        Console.WriteLine($"Crew-Mitglieder: {CrewMitglieder}");
    }
}

public class Artikel
{
    private double preis;
    private string marke;
    public double Preis
    {
        get { return preis; }
        set { preis = value; }
    }
    public string Marke
    {
        get { return marke; }
        set { marke = value; }
    }

    public Artikel(double Preis, string Marke)
    {
        this.preis = Preis;
        this.marke = Marke;
    }

    public void ZeigeArtikel()
    {
        Console.WriteLine($"\nPreis: {Preis}");
        Console.WriteLine($"Marke: {Marke}");
    }
}

public class Hund
{
    private string name;
    private string rasse;
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public string Rasse
    {
        get { return rasse; }
        set { rasse = value; }
    }

    public Hund(string Name, string Rasse)
    {
        this.name = Name;
        this.rasse = Rasse;
    }

    public void ZeigeHund()
    {
        Console.WriteLine($"\nName: {Name}");
        Console.WriteLine($"Rasse: {Rasse}");
    }
}

public class Program1
{
    public static void Main()
    {
        Console.Write("Anzahl Masten eingeben: ");
        int anzahlMasten = int.Parse(Console.ReadLine());

        Console.Write("Crew-Mitglieder eingeben: ");
        int crewMitglieder = int.Parse(Console.ReadLine());

        Console.Write("\nPreis eingeben: ");
        double preis = double.Parse(Console.ReadLine());

        Console.Write("Marke eingeben: ");
        string marke = Console.ReadLine();

        Console.Write("\nName des Hundes eingeben: ");
        string name = Console.ReadLine();

        Console.Write("Rasse des Hundes eingeben: ");
        string rasse = Console.ReadLine();

        Segelschiff segelschiff = new Segelschiff(anzahlMasten, crewMitglieder);
        Artikel artikel = new Artikel(preis, marke);
        Hund hund = new Hund(name, rasse);

        segelschiff.ZeigeSegelschiff();
        artikel.ZeigeArtikel();
        hund.ZeigeHund();
    }
}
