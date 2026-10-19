public class Drohne : Transportmittel
{
    public Drohne(string name) : base(name)
    {
    }

    public override string Bewegen()
    {
        return "fliegt durch die Luft.";
    }
}