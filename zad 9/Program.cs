using System;
using System.Linq;
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

        Enemy enemy1 = new Enemy("Gradfl", "Goblin", 30, 50, 85, 0, true, 5.5, 10, 10);
        Enemy enemy2 = new Enemy("Blabpfl", "Golem", 25, 50, 85, 0, true, 0, 30, 5);

        ICharacter decoratedEnemy1 = new PowerBoostDecorator(enemy1, 5.0);
        ICharacter decoratedEnemy2 = new PowerBoostDecorator(enemy2, 5.0);

        Console.WriteLine("Stwórz swoją postać:");
        bool tworzenie = true;

        while (tworzenie)
        {
            Console.WriteLine("Podaj imię: ");
            string imie = Console.ReadLine();

            string klasa;
            while (true)
            {
                Console.Write("Wybierz klasę: (Magik, Tank, Miecznik, Łucznik) ");
                klasa = Console.ReadLine();
                if (klasyPostaci.Any(klasyPostaci => klasyPostaci.Klasa == klasa)) break;
                else Console.WriteLine("Nieprawidłowa klasa. Spróbuj ponownie.");
            }

            double hp = klasyPostaci.Where(k => k.Klasa == klasa).Select(k => k.HP).First();
            double mana = klasyPostaci.Where(k => k.Klasa == klasa).Select(k => k.Mana).First();

            int sila = PobierzWartosc("Podaj siłę (20-35): ", 20, 35);
            int zrecznosc = PobierzWartosc("Podaj zręczność (30-60): ", 30, 60);
            int inteligencja;
            if (klasa == "Magik")
            {
                inteligencja = PobierzWartosc("Podaj inteligencję (45-80): ", 45, 80);
            }
            else
            {
                inteligencja = PobierzWartosc("Podaj inteligencję (20-65): ", 20, 65);
            }
            int szczescie;
            if (klasa == "Łucznik")
            {
                szczescie = PobierzWartosc("Podaj szczęście (50-70): ", 50, 70);
            }
            else
            {
                szczescie = PobierzWartosc("Podaj szczęście (30-50): ", 30, 50);
            }

            Player player = new List<Player>
            {
                new Player(imie, klasa, sila, zrecznosc, inteligencja, hp, mana, szczescie)
            }.FirstOrDefault();

            WyswietlDaneGracza(player);
            tworzenie = false;
        }

        Console.WriteLine("Staty wrogów: ");
        WyswietlStatyEnemy(decoratedEnemy1);
        WyswietlStatyEnemy(decoratedEnemy2);
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
        player.WyswietlStaty();
    }

    public static void WyswietlStatyEnemy(ICharacter enemy)
    {
        enemy.WyswietlStaty();
    }
}

public class Player : ICharacter
{
    public string Imie { get; private set; }
    public string Klasa { get; private set; }
    public double Sila { get; private set; }
    public int Zrecznosc { get; private set; }
    public double Inteligencja { get; private set; }
    public double HP { get; private set; }
    public double Mana { get; private set; }
    public double Szczescie { get; private set; }

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

    public void WyswietlStaty()
    {
        Console.WriteLine($"Staty twojej postaci - Imie: {Imie}, Klasa: {Klasa},\n HP: {HP}, Mana: {Mana},\n Siła: {Sila}, Zręczność: {Zrecznosc},\n Inteligencja: {Inteligencja}, Szczęście: {Szczescie}\n");
    }
}

public class Enemy : ICharacter
{
    public string Imie { get; private set; }
    public string Klasa { get; private set; }
    public double Sila { get; private set; }
    public double Mana { get; private set; }
    public double HP { get; private set; }
    public double Szczescie { get; private set; }
    public bool Agresja { get; private set; }
    public double LifeSteal { get; private set; }
    public double APRes { get; private set; }
    public double ADRes { get; private set; }

    public Enemy(string Imie, string Klasa, double Sila, double Mana, double HP, double Szczescie, bool Agresja, double LifeSteal, double APRes, double ADRes)
    {
        this.Imie = Imie;
        this.Klasa = Klasa;
        this.Sila = Sila;
        this.Mana = Mana;
        this.HP = HP;
        this.Szczescie = Szczescie;
        this.Agresja = Agresja;
        this.LifeSteal = LifeSteal;
        this.APRes = APRes;
        this.ADRes = ADRes;
    }

    public void WyswietlStaty()
    {
        Console.WriteLine($"Imie: {Imie}, Klasa: {Klasa}, HP: {HP}, Mana: {Mana}, Siła: {Sila}, Agresja: {Agresja}, Life Steal: {LifeSteal}, APRes: {APRes}, ADRes: {ADRes}");
    }
}

public interface ICharacter
{
    string Imie { get; }
    string Klasa { get; }
    double Sila { get; }
    double Mana { get; }
    double HP { get; }
    double Szczescie { get; }
    void WyswietlStaty();
}

public abstract class CharacterDecorator : ICharacter
{
    protected ICharacter _character;

    public CharacterDecorator(ICharacter character)
    {
        _character = character;
    }

    public virtual string Imie => _character.Imie;
    public virtual string Klasa => _character.Klasa;
    public virtual double Sila => _character.Sila;
    public virtual double Mana => _character.Mana;
    public virtual double HP => _character.HP;
    public virtual double Szczescie => _character.Szczescie;

    public virtual void WyswietlStaty()
    {
        _character.WyswietlStaty();
    }
}

public class PowerBoostDecorator : CharacterDecorator
{
    private double _boostAmount;

    public PowerBoostDecorator(ICharacter character, double boostAmount) : base(character)
    {
        _boostAmount = boostAmount;
    }

    public override double Sila
    {
        get
        {
            if (_character is Enemy enemy && enemy.HP < enemy.HP * 0.4)
            {
                return _character.Sila + _boostAmount;
            }
            return _character.Sila;
        }
    }

    public override void WyswietlStaty()
    {
        base.WyswietlStaty();
        if (_character is Enemy enemy && enemy.HP < enemy.HP * 0.4)
        {
            Console.WriteLine($"Agresja: Siła przeciwnika zwiększona o {_boostAmount}");
        }
    }
}
