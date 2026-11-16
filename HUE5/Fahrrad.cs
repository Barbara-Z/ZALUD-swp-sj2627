public class Fahrrad : Transportmittel
{
    public Fahrrad(string name) : base(name)
    {
    }

    public override string Bewegen()
    {
        return "wird mit Muskelkraft bewegt.";
    }
}