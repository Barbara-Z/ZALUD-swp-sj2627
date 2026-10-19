public abstract class Transportmittel
{
    public string Name { get; }

    protected Transportmittel(string name)
    {
        Name = name;
    }

    public abstract string Bewegen();

    public void Vorstellen()
    {
        Console.WriteLine($"{Name}: {Bewegen()}");
    }
}