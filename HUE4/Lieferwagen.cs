public class Lieferwagen : Transportmittel, IAutonomSteuerbar
{
    public Lieferwagen(string name) : base(name)
    {
    }

    public override string Bewegen()
    {
        return "fährt auf der Straße.";
    }

    public void FahreAutonom(string ziel)
    {
        Console.WriteLine($"\n{Name} fährt autonom nach {ziel}.");
    }
}