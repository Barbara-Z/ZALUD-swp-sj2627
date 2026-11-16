public class Program
{
    public static void Main()
    {
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
            Console.WriteLine("0. Beenden");
            auswahl = Console.ReadLine();

            switch (auswahl)
            {
                case "1":
                    Console.WriteLine("Fahrzeugtypen:");
                    Console.WriteLine("1. Fahrrad");
                    Console.WriteLine("2. Lieferwagen");
                    Console.WriteLine("3. Drohne");
                    Console.WriteLine("4. Autonomes Taxi");
                    string fahrzeugTyp = Console.ReadLine();
                    Console.WriteLine("Name des Fahrzeugs eingeben:");
                    string name = Console.ReadLine();

                    switch (fahrzeugTyp)
                    {
                        case "1":
                            flotte.Add(new Fahrrad(name));
                            break;
                        case "2":
                            flotte.Add(new Lieferwagen(name));
                            break;
                        case "3":
                            flotte.Add(new Drohne(name));
                            break;
                        case "4":
                            flotte.Add(new AutonomesTaxi(name));
                            break;
                        default:
                            Console.WriteLine("Ungültige Auswahl.");
                            break;
                    }
                    break;

                case "2":
                    foreach (Transportmittel fahrzeug in flotte)
                    {
                        fahrzeug.Vorstellen();
                    }
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
}

/*
Pseudocode:

DO
    Menü anzeigen: 1 Hinzufügen, 2 Flotte anzeigen, 0 Beenden
    auswahl = Console.ReadLine()

    SWITCH (auswahl)
        CASE "1":
            Fahrzeugtypen anzeigen und fahrzeugTyp einlesen
            name einlesen

            SWITCH (fahrzeugTyp)
                CASE "1": flotte.Add(neues Fahrrad(name))
                CASE "2": flotte.Add(neuer Lieferwagen(name))
                CASE "3": flotte.Add(neue Drohne(name))
                CASE "4": flotte.Add(neues AutonomesTaxi(name))
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
