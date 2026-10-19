public class Program1
{
    public static void Main()
    {
        Transportmittel lieferwagen = new Lieferwagen("E-Transporter");
        Transportmittel drohne = new Drohne("Drohne ");

        List<Transportmittel> flotte = new List<Transportmittel>
        {
            new Fahrrad("Citybike"),
            lieferwagen,
            drohne
        };

        foreach (Transportmittel tmittel in flotte)
        {
            tmittel.Vorstellen();
        }
    }
}