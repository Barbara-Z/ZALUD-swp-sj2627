using System;

//Singleton soll von einer Klasse nur ein einziges Objekt geben


public class Singleton
{
    private static Singleton? singleton;
    public int x;

    private Singleton()
    {
    }

    public static Singleton getInstance()
    {
        if (singleton == null) //neues Objekt erstellen
        {
            singleton = new Singleton();
        }
        return singleton; //immer dasselbe Objekt zurückgeben
    }
}

public class Program2
{
    public static void Main()
    {
        Singleton singleton = Singleton.getInstance(); //Singleton darf nicht mit new erstellt werden, da Konstruktor private ist
        singleton.x = 10;
        Console.WriteLine(singleton.x);
    }
}