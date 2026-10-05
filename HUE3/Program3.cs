using System;

//Die Factory Method erstellt ein Objekt, ohne dass das Hauptprogramm direkt wissen muss, welche konkrete Klasse erzeugt wird.
//Methode für Objekterzeugung zuständig
public class Produkt
{
}

public class KonkretesProdukt : Produkt
{
}

public abstract class Erzeuger
{
    public abstract Produkt fabrikmethode();

    public void eineOperation() //ruft Fabrikmethode auf nicht Konkretesprodukt, damit KonkreterErzeuger entscheidet
    {
        Produkt produkt = fabrikmethode();
    }
}

public class KonkreterErzeuger : Erzeuger //entscheidet welches Produkt erzeugt wird, indem er die Fabrikmethode überschreibt und ein konkretes Produkt zurückgibt
{
    public override Produkt fabrikmethode()
    {
        return new KonkretesProdukt();
    }
}

public class Program3
{
    public static void Main()
    {
        Erzeuger erzeuger = new KonkreterErzeuger(); //Erzeuger → Typ der Variable, KonkreterErzeuger → tatsächlich erzeugtes Objekt
        erzeuger.eineOperation();
    }
}