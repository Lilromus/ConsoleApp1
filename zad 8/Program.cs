using System;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;


public class Program
{
    public static void Main(string[] args)
    {

        var klasyPostaci = new List<(string Klasa, double HP, double Mana)>
        {
            ("Magik", 100, 100),
            ("Miecznik", 100, 50),
            ("Tank", 150, 50),
            ("Łucznik", 100, 50)
        };

        Console.WriteLine("Stworz swoją postać:");
        bool tworzenie = true;

        while (tworzenie)
        {
            Console.WriteLine("Podaj imię: ");
            string imie = Console.ReadLine();

            string klasa;
            while (true)
            {
                Console.Write("Wybierz klasę: (Magik, Tank, Miecznik, Łucznik)");
                klasa = Console.ReadLine();
                if (klasyPostaci.Any(klasyPostaci => klasyPostaci.Klasa == klasa)) break;
                else Console.WriteLine("Nieprawidłowa klasa. Spróbuj ponownie.");
            }

            double hp = klasyPostaci.Where(k => k.Klasa == klasa).Select(k => k.HP).First();
            double mana = klasyPostaci.Where(k => k.Klasa == klasa).Select(k => k.Mana).First();

            int sila = PobierzWartosc("Podaj siłe (20-35): ", 20, 35);
            int zrecznosc = PobierzWartosc("Podaj zręczność (30-60): ", 30, 60);
            int inteligencja = PobierzWartosc("Podaj inteligencję (20-65): ", 20, 65);
            int szczescie = PobierzWartosc("Podaj szczęście (30-50): ", 30, 50);

            Player player = new List<Player>
            {
                new Player(imie, klasa, sila, zrecznosc, inteligencja, hp, mana, szczescie)
            }.FirstOrDefault();

            WyswietlDaneGracza(player);

            Console.WriteLine("Czy chciałbys stworzyć kolejną postać?(Tak/Nie)");
            string wybor = Console.ReadLine();
            if (wybor == "Nie")
            {
                tworzenie = false;
            }
        }
    }

    public static int PobierzWartosc(string komunikat, int minimalnaWartosc, int maksymalnaWartosc)
    {
        int wprowadzonaWartosc;
        while (true)
        {
            Console.Write(komunikat);
            string wprowadzonyTekst = Console.ReadLine();
            bool czyPoprawnaLiczba = int.TryParse(wprowadzonyTekst, out wprowadzonaWartosc);

            if (czyPoprawnaLiczba && wprowadzonaWartosc >= minimalnaWartosc && wprowadzonaWartosc <= maksymalnaWartosc)
            {
                break; 
            }
            else
            {
                Console.WriteLine($"Wartość musi być liczbą pomiędzy {minimalnaWartosc} a {maksymalnaWartosc}.");
            }
        }
        return wprowadzonaWartosc;
    }

    public static void WyswietlDaneGracza(Player player)
    {
        Console.WriteLine("Dane o Graczu:");
        Console.WriteLine($"Imie: {player.Imie}");
        Console.WriteLine($"Klasa: {player.Klasa}");
        Console.WriteLine($"Siła: {player.Sila}");
        Console.WriteLine($"Zręczność: {player.Zrecznosc}");
        Console.WriteLine($"Inteligencja: {player.Inteligencja}");
        Console.WriteLine($"HP: {player.HP}");
        Console.WriteLine($"Mana: {player.Mana}");
        Console.WriteLine($"Szczęście: {player.Szczescie}");
    }
}

public class Player
{
    public string Imie { get; set; }
    public string Klasa { get; set; }
    public double Sila { get; set; }
    public int Zrecznosc { get; set; }
    public double Inteligencja { get; set; }
    public double HP { get; set; }
    public double Mana { get; set; }
    public double Szczescie { get; set; }

    public Player(string Imie, string Klasa, double Sila, int Zrecznosc, double Inteligencja, double HP, double Mana, double Szczescie)
    {
        this.Imie = Imie;
        this.Klasa = Klasa;
        this.Sila = Sila;
        this.Zrecznosc = Zrecznosc;
        this.Inteligencja = Inteligencja;
        this.HP = HP;
        this.Mana = Mana;
        this.Szczescie = Szczescie;
    }
}
