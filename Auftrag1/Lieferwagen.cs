public class Lieferwagen : Transportmittel
{
    public Lieferwagen(string name) : base(name)
    {
    }

    public override string Bewegen()
    {
        return "fährt auf der Straße.";
    }
}