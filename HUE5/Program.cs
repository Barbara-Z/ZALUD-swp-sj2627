using System.Text.Json;

public class Program
{
    public static void Main()
    {
        TransportmittelDatensatz datensatz = new TransportmittelDatensatz
        {
            Typ = "Drohne",
            Name = "Drohne A"
        }; //Objekt erstellen und mit Werten füllen

        string kompaktJson = JsonSerializer.Serialize(datensatz); //Objekt in JSON String umwandeln
        Console.WriteLine(kompaktJson); //Ausgabe Json String

        JsonSerializerOptions optionen = new JsonSerializerOptions //Optionen für die Serialisierung
        {
            WriteIndented = true //Formatiert den JSON String mit Einrückungen und Zeilenumbrüchen
        };
        string formatiertJson = JsonSerializer.Serialize(datensatz, optionen);
        Console.WriteLine(formatiertJson); //Ausgabe ist Formatiert (mit Einrückungen und Zeilenumbrüchen)

        string json = "{\"Typ\":\"Fahrrad\",\"Name\":\"Citybike\"}"; //JSON String einlesen
        TransportmittelDatensatz? deserialisierterDatensatz =
            JsonSerializer.Deserialize<TransportmittelDatensatz>(json); //JSON String in Objekt umwandeln
        Console.WriteLine($"Typ: {deserialisierterDatensatz?.Typ}"); //Null-Conditional Operator (?.) prüft, ob deserialisierterDatensatz null ist, bevor auf Typ zugegriffen wird
        Console.WriteLine($"Name: {deserialisierterDatensatz?.Name}");

        Transportmittel lieferwagen = new Lieferwagen("E-Transporter");
        Transportmittel drohne = new Drohne("Drohne");
        Transportmittel taxi = new AutonomesTaxi("Autonomes Taxi");

        List<Transportmittel> flotte = new List<Transportmittel>
        {
            new Fahrrad("Citybike"),
            lieferwagen,
            drohne,
            taxi
        };

        string auswahl;
        do
        {
            Console.WriteLine("Menü:");
            Console.WriteLine("1. Fahrzeug hinzufügen");
            Console.WriteLine("2. Flotte anzeigen");
            Console.WriteLine("3. Flotte speichern");
            Console.WriteLine("4. Flotte laden");
            Console.WriteLine("0. Beenden");
            auswahl = Console.ReadLine() ?? string.Empty;

            switch (auswahl)
            {
                case "1":
                    Console.WriteLine("Fahrzeugtypen:");
                    Console.WriteLine("1. Fahrrad");
                    Console.WriteLine("2. Lieferwagen");
                    Console.WriteLine("3. Drohne");
                    Console.WriteLine("4. Autonomes Taxi");
                    string fahrzeugTyp = Console.ReadLine() ?? string.Empty;
                    Console.WriteLine("Name des Fahrzeugs eingeben:");
                    string name = Console.ReadLine() ?? string.Empty;

                    // Die Menüauswahl ist nummerisch; die Factory erwartet die festgelegten Typnamen.
                    string typ = fahrzeugTyp switch
                    {
                        "1" => "Fahrrad",
                        "2" => "Lieferwagen",
                        "3" => "Drohne",
                        "4" => "AutonomesTaxi",
                        _ => fahrzeugTyp
                    };

                    try
                    {
                        // Die Factory erstellt das passende Fahrzeug; Add fügt es der vorhandenen Flotte hinzu.
                        flotte.Add(TransportmittelFactory.Erzeuge(typ, name));
                    }
                    // Die Factory wirft bei einem unbekannten Typ eine ArgumentException
                    catch (ArgumentException exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                    break;

                case "2":
                    foreach (Transportmittel fahrzeug in flotte)
                    {
                        fahrzeug.Vorstellen();
                    }
                    break;

                case "3":
                    FlotteSpeichern(flotte);
                    break;

                case "4":

                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Ungültige Menüauswahl.");
                    break;
            }
        }
        while (auswahl != "0");
    }

    public static void FlotteSpeichern(List<Transportmittel> flotte)
    {
        // Jedes Fahrzeug wird in einen Datensatz mit Typ und Name umgewandelt.
        List<TransportmittelDatensatz> datensaetze = new List<TransportmittelDatensatz>();
        foreach (Transportmittel fahrzeug in flotte)
        {
            datensaetze.Add(TransportmittelFactory.ErzeugeDatensatz(fahrzeug));
        }

        // WriteIndented formatiert das JSON für bessere Lesbarkeit.
        JsonSerializerOptions optionen = new JsonSerializerOptions
        {
            WriteIndented = true
        };
        string json = JsonSerializer.Serialize(datensaetze, optionen);

        // Die Datei wird im aktuellen Arbeitsverzeichnis erstellt oder überschrieben.
        string dateipfad = "fahrzeugflotte.json";
        File.WriteAllText(dateipfad, json);

        // Der vollständige Pfad zeigt an, wo die Datei gespeichert wurde.
        Console.WriteLine($"Flotte gespeichert: {Path.GetFullPath(dateipfad)}");
    }
}

/*
Pseudocode:

DO
 
    auswahl = Console.ReadLine()

    SWITCH (auswahl)
        CASE "1":
            Fahrzeugtypen anzeigen und fahrzeugTyp einlesen
            name einlesen

            SWITCH (fahrzeugTyp)
                CASE "1"-"4": flotte.Add(TransportmittelFactory.Erzeuge(typ, name))
                DEFAULT: ungültige Auswahl ausgeben

        CASE "2":
            FOREACH fahrzeug IN flotte
                fahrzeug.Vorstellen()

        CASE "0":
            Programm beenden

        DEFAULT:
            ungültige Menüauswahl ausgeben
WHILE (auswahl != "0")
*/

/*Switch-case und If-Else im Vergleich
switch vergleicht einen Wert mit mehreren festen Möglichkeiten, zum Beispiel der Menüauswahl "1", "2" oder "0". 
Ein passender case wird ausgeführt; default behandelt alle nicht passenden Werte.

Eine if-else-Verkettung prüft Bedingungen der Reihe nach. 
Sie ist flexibler und eignet sich etwa für Bereiche oder komplexe Bedingungen, 
zum Beispiel alter >= 18. Für feste Menüoptionen ist switch meist übersichtlicher.*/
