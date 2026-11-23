public static class TransportmittelFactory
{
    // Eine statische Factory kann ohne Objekt verwendet werden und bündelt die Fahrzeugerzeugung an einer Stelle.
    public static Transportmittel Erzeuge(string typ, string name)
    {
        // Der switch-Ausdruck vergleicht den Typnamen und gibt das passende konkrete Fahrzeug zurück.
        return typ switch
        {
            "Fahrrad" => new Fahrrad(name),
            "Lieferwagen" => new Lieferwagen(name),
            "Drohne" => new Drohne(name),
            "AutonomesTaxi" => new AutonomesTaxi(name),
            // _ steht für alle nicht aufgeführten Typen; throw bricht mit einer aussagekräftigen Ausnahme ab.
            _ => throw new ArgumentException($"Unbekannter Fahrzeugtyp: {typ}", nameof(typ)) // nameof liefert den Namen des Parameters, der die Ausnahme ausgelöst hat.
        };
    }

    // Ermittelt anhand des tatsächlichen Objekttyps die Textbezeichnung für den Datensatz.
    public static TransportmittelDatensatz ErzeugeDatensatz(Transportmittel transportmittel)
    {
        string typ = transportmittel switch
        {
            Fahrrad => "Fahrrad",
            Lieferwagen => "Lieferwagen",
            Drohne => "Drohne",
            AutonomesTaxi => "AutonomesTaxi",
            // Nicht unterstützte Fahrzeugklassen können so nicht unbemerkt falsch gespeichert werden.
            _ => throw new ArgumentException(
                $"Unbekannter Fahrzeugtyp: {transportmittel.GetType().Name}",
                nameof(transportmittel))
        };

        // Typ und Name werden in das einfache, serialisierbare Datensatzobjekt kopiert.
        return new TransportmittelDatensatz
        {
            Typ = typ,
            Name = transportmittel.Name
        };
    }
}