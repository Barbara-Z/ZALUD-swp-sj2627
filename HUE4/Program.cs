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