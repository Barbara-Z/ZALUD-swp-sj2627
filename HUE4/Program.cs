public class Program1
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

        //Vorhersage vor dem Start:
        //Fahrrad -> Fahrrad.Bewegen() -> "wird mit Muskelkraft bewegt."
        //Lieferwagen -> Lieferwagen.Bewegen() -> "fährt auf der Straße."   
        //Drohne -> Drohne.Bewegen() -> "fliegt durch die Luft."
        //AutonomesTaxi -> AutonomesTaxi.Bewegen() -> "fährt selsbtständig auf der Straße."

        foreach (Transportmittel tmittel in flotte)
        {
            tmittel.Vorstellen();
        }

        IAutonomSteuerbar autonomerLieferwagen = (IAutonomSteuerbar)lieferwagen;
        IAutonomSteuerbar autonomeDrohne = (IAutonomSteuerbar)drohne;
        IAutonomSteuerbar autonomesTaxi = (IAutonomSteuerbar)taxi;

        autonomerLieferwagen.FahreAutonom("Depot");
        autonomeDrohne.FahreAutonom("Spengergasse");
        autonomesTaxi.FahreAutonom("Hauptbahnhof");
    }
}

/* 4. Fahrrad implementiert Interface nicht, weil es nicht autonom steuerbar ist und deswegen muss man es gar nicht aufnehmen.
        Die Methode sollte nicht in Transportmittel stehen, weil nicht alle Transportmittel davon betroffen sind.
    Die Basisklasse ist abstrakt, weil man kein Transportmittel direkt erzeugen kann. Man kann nur konkrete Klassen erzeugen, die von Transportmittel erben.
    Die Autonome Steuerung ist ein Interface, weil die Methode FahreAutonom nur von bestimmten Klassen implementiert werden muss.
*/

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
