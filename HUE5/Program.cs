using System.Text.Json;

public class Program
{
    private const string DateipfadFlotte = "fahrzeugflotte.json";

    public static void Main()
    {
        /*TransportmittelDatensatz datensatz = new TransportmittelDatensatz
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
        */

        List<Transportmittel> flotte = new List<Transportmittel>();
        if (File.Exists(DateipfadFlotte))
        {
            FlotteLaden(flotte);
        }

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
                    FlotteLaden(flotte);
                    break;

                case "0":
                    Console.Write("Flotte vor dem Beenden speichern? (ja/nein): ");
                    string speichern = Console.ReadLine() ?? string.Empty;
                    if (speichern.Equals("ja", StringComparison.OrdinalIgnoreCase))
                    {
                        FlotteSpeichern(flotte);
                    }
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
        try
        {
            File.WriteAllText(DateipfadFlotte, json);
        }
        catch (IOException exception)
        {
            Console.WriteLine($"Datei konnte nicht gespeichert werden: {exception.Message}");
            return;
        }

        // Der vollständige Pfad zeigt an, wo die Datei gespeichert wurde.
        Console.WriteLine($"Flotte gespeichert: {Path.GetFullPath(DateipfadFlotte)}");
    }

    public static void FlotteLaden(List<Transportmittel> flotte)
    {
        if (!File.Exists(DateipfadFlotte))
        {
            Console.WriteLine("Datei nicht gefunden.");
            return;
        }

        string json;
        try
        {
            json = File.ReadAllText(DateipfadFlotte);
        }
        catch (IOException exception)
        {
            Console.WriteLine($"Datei konnte nicht gelesen werden: {exception.Message}");
            return;
        }

        // JSON wird zuerst in Datensätze eingelesen; bei ungültigem JSON bleibt die Flotte unverändert.
        List<TransportmittelDatensatz>? datensaetze;
        try
        {
            datensaetze = JsonSerializer.Deserialize<List<TransportmittelDatensatz>>(json);
        }
        catch (JsonException exception)
        {
            Console.WriteLine($"Ungültiges JSON: {exception.Message}");
            return;
        }

        if (datensaetze is null)
        {
            Console.WriteLine("Keine Fahrzeugliste gefunden.");
            return;
        }

        // Fahrzeuge zunächst separat erzeugen, damit fehlerhafte Datensätze die bestehende Flotte nicht verändern.
        List<Transportmittel> neueFlotte = new List<Transportmittel>();
        foreach (TransportmittelDatensatz? datensatz in datensaetze)
        {
            if (datensatz is null)
            {
                Console.WriteLine("Leerer Datensatz wurde übersprungen.");
                continue;
            }

            if (string.IsNullOrWhiteSpace(datensatz.Name))
            {
                Console.WriteLine($"Datensatz vom Typ '{datensatz.Typ}' hat keinen Namen und wurde übersprungen.");
                continue;
            }

            try
            {
                neueFlotte.Add(TransportmittelFactory.Erzeuge(datensatz.Typ, datensatz.Name));
            }
            catch (ArgumentException)
            {
                Console.WriteLine($"Unbekannter Typ '{datensatz.Typ}', Datensatz wurde übersprungen.");
            }
        }

        // Erst nach erfolgreicher Umwandlung wird die bestehende Flotte ersetzt.
        flotte.Clear();
        flotte.AddRange(neueFlotte);

        Console.WriteLine($"Geladen: {neueFlotte.Count} Fahrzeuge.");
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
