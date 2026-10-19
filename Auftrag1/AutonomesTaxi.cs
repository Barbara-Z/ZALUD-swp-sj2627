public class AutonomesTaxi : Transportmittel, IAutonomSteuerbar
{
    public AutonomesTaxi(string name) : base(name)
    {
    }

    public override string Bewegen()
    {
        return "fährt selbstständig auf der Straße.";
    }

    public void FahreAutonom(string ziel)
    {
        Console.WriteLine($"\n{Name} fährt autonom zum Ziel: {ziel}.");
    }
}