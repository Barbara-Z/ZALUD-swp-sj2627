public class Program1
{
    public static void Main()
    {
        Transportmittel lieferwagen = new Lieferwagen("E-Transporter");
        Transportmittel drohne = new Drohne("Drohne ");
        Transportmittel taxi = new AutonomesTaxi("Autonomes Taxi");

        List<Transportmittel> flotte = new List<Transportmittel>
        {
            new Fahrrad("Citybike"),
            lieferwagen,
            drohne,
            taxi
        };

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