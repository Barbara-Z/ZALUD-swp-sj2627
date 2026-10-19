public class Drohne : Transportmittel, IAutonomSteuerbar
{
    public Drohne(string name) : base(name)
    {
    }

    public override string Bewegen()
    {
        return "fliegt durch die Luft.";
    }
    public void FahreAutonom(string ziel)
    {
        Console.WriteLine($"{Name} fährt autonom zum Ziel: {ziel}.");
    }
}