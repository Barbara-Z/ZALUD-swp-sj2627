using System;

public interface IBewertbar
{
    void Bewerten(int punkte);
}

public class Person
{
    public string Name { get; set; }
    public int Alter { get; set; }

    public Person(string name, int alter)
    {
        Name = name;
        Alter = alter;
    }

    public void Vorstellen() //wird von der Klasse Schueler geerbt, die von der Klasse Person abgeleitet ist
    {
        Console.WriteLine($"\nIch heiße {Name} und bin {Alter} Jahre alt.");
    }
}

public class Schueler : Person, IBewertbar //erbt von Person und implementiert zusätzlich das Interface IBewertbar
{
    public string Klasse { get; set; }
    public int SchuelerNummer { get; set; }
    public int LetztePunkte { get; set; }

    public Schueler(string name, int alter, string klasse, int schuelerNummer)
        : base(name, alter) // Aufruf des Konstruktors der Klasse Person
    {
        Klasse = klasse;
        SchuelerNummer = schuelerNummer;
    }

    public void ZeigeSchuelerDaten()
    {
        Console.WriteLine($"Klasse: {Klasse}");
        Console.WriteLine($"Schülernummer: {SchuelerNummer}");
    }

    public void Bewerten(int punkte)
    {
        LetztePunkte = punkte;
        Console.WriteLine($"Bewertung: {punkte} Punkte");
    }
}

public class Program
{
    public static void Main()
    {
        Console.WriteLine("\nSchülerdaten für die Klasse 4AHWII erfassen\n\n");

        Console.Write("Name eingeben: ");
        string name = Console.ReadLine();

        Console.Write("Alter eingeben: ");
        int alter = int.Parse(Console.ReadLine());

        Console.Write("Schülernummer eingeben: ");
        int schuelernr = int.Parse(Console.ReadLine());

        Console.Write("Bewertung eingeben: ");
        int bewertung = int.Parse(Console.ReadLine());

        Schueler schueler = new Schueler(name, alter, "4AHWII", schuelernr);

        schueler.Vorstellen();
        schueler.ZeigeSchuelerDaten();
        schueler.Bewerten(bewertung);
    }
}