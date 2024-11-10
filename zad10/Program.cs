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

        IPostac decoratedEnemy1 = new PowerBoostDekator(enemy1, 5.0);
        IPostac decoratedEnemy2 = new PowerBoostDekator(enemy2, 5.0);

        Console.WriteLine("Stwórz swoją postać:");
        bool tworzenie = true;

        Player player = null;

        while (tworzenie)
        {
            Console.WriteLine("Podaj imię: ");
            string imie = Console.ReadLine();

            string klasa;
            while (true)
            {
                Console.Write("Wybierz klasę: (Magik, Tank, Miecznik, Lucznik) ");
                string input = Console.ReadLine();
                if (input != null)
                {
                    klasa = input.Trim();
                }
                else
                {
                    klasa = string.Empty; 
                }
                if (klasyPostaci.Any(k => k.Klasa == klasa))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Nieprawidłowa klasa. Spróbuj ponownie.");
                }
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

            player = new Player(imie, klasa, sila, zrecznosc, inteligencja, hp, mana, szczescie);

            WyswietlDaneGracza(player);
            tworzenie = false;
        }


        Console.WriteLine("Wybierz przeciwnika:");
        Console.WriteLine("1. Gradfl (Goblin)");
        WyswietlDanePrzeciwnik(enemy1);
        Console.WriteLine("2. Blabpfl (Golem)");
        WyswietlDanePrzeciwnik(enemy2);

        int wyborPrzeciwnika = 0;
        while (true)
        {
            Console.Write("Wybierz 1 lub 2: ");
            string wybor = Console.ReadLine();
            if (wybor == "1") wyborPrzeciwnika = 1;
            else if (wybor == "2") wyborPrzeciwnika = 2;
            else Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");

            if (wyborPrzeciwnika != 0) break;
        }

        IPostac przeciwnik;

        if (wyborPrzeciwnika == 1)
        {
            przeciwnik = decoratedEnemy1;
        }
        else
        {
            przeciwnik = decoratedEnemy2;
        }


        bool walka = true;
        while (walka)
        {
         
            Console.WriteLine("\nTwoja tura:");
            Console.WriteLine("Wybierz umiejętność do użycia:");
            Console.WriteLine("1. Podstawowy atak");
            Console.WriteLine("2. Umiejętność specjalna");

            string wyborUmiejetnosci = Console.ReadLine();
            switch (wyborUmiejetnosci)
            {
                case "1":
                    player.UseSkill("BasicAttack");
                    break;
                case "2":
                    player.UseSkill("SpecialSkill");
                    break;
                default:
                    Console.WriteLine("Nieprawidłowy wybór umiejętności. Wykonuję podstawowy atak.");
                    player.UseSkill("BasicAttack");
                    break;
            }

            przeciwnik.HP -= player.Sila;  
            Console.WriteLine($"{przeciwnik.Imie} ma teraz {przeciwnik.HP} HP.\n");

            if (przeciwnik.HP <= 0)
            {
                Console.WriteLine($"{przeciwnik.Imie} został pokonany!");
                break;  
            }

            Console.WriteLine("\nTura przeciwnika:");
            if (przeciwnik.CanAct())
            {
                przeciwnik.Sila = przeciwnik.Sila + 10;  
                player.HP -= przeciwnik.Sila;
                Console.WriteLine($"{przeciwnik.Imie} atakuje i zadaje {przeciwnik.Sila} obrażeń. Twoje HP: {player.HP}.\n");
            }

            if (player.HP <= 0)
            {
                Console.WriteLine($"{player.Imie} został pokonany!");
                break; 
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
        player.WyswietlStaty();
    }

    public static void WyswietlDanePrzeciwnik(Enemy enemy)
    {
        enemy.WyswietlStaty();
    }
}

public interface IBasicSkill
{
    void BasicAttack();
}

public interface ISpecialSkill
{
    void SpecialSkill();
}


public class Player : IPostac, IBasicSkill, ISpecialSkill
{
    public string Imie { get; set; }
    public string Klasa { get; set; }
    public double Sila { get; set; }
    public int Zrecznosc { get; set; }
    public double Inteligencja { get; set; }
    public double HP { get; set; }
    public double Mana { get; set; }
    public double Szczescie { get; set; }

    private Random random = new Random();

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

    public void BasicAttack()
    {
        bool doubleDamage = random.Next(0, 100) < this.Szczescie;
        double damage = this.Sila * (doubleDamage ? 2 : 1);
        Console.WriteLine($"{Imie} atakuje podstawową umiejętnością zadając {damage} obrażeń!");
    }

    public void SpecialSkill()
    {
        double specialDamage = this.Inteligencja * 1.5;
        Console.WriteLine($"{Imie} używa umiejętności specjalnej zadając {specialDamage} obrażeń!");
    }

    public void UseSkill(string skillType)
    {
        if (skillType == "BasicAttack")
        {
            BasicAttack();
        }
        else if (skillType == "SpecialSkill")
        {
            SpecialSkill();
        }
    }

    public bool CanAct() => this.HP > 0;
    public void WyswietlStaty()
    {
        Console.WriteLine($"Imię: {Imie}, Klasa: {Klasa}, HP: {HP}, Mana: {Mana}, Sila: {Sila}, Zrecznosc: {Zrecznosc}, Inteligencja: {Inteligencja}, Szczescie: {Szczescie}");
    }
}


public class Enemy : IPostac
{
    public string Imie { get; set; }
    public string Klasa { get; set; }
    public double Sila { get; set; }
    public double Mana { get; set; }
    public double HP { get; set; }
    public double Szczescie { get; set; }
    public bool Agresja { get; set; } //Gdy HP moba spada ponizej 40% to mob dostaje zwieksząną siłę
    public double LifeSteal { get; set; }
    public double APRes { get; set; } // vs atakom magicznym
    public double ADRes { get; set; } // vs atakom fizycznym
    public bool IsStunned { get; set; }

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
        IsStunned = false;
       
}

    public bool CanAct()
    {
        if (IsStunned)
        {
            IsStunned = false;
            return false;
        }
        return true;
    }


    public void WyswietlStaty()
    {
        Console.WriteLine($"Imie: {Imie}, Klasa: {Klasa}, HP: {HP}, Mana: {Mana}, Siła: {Sila}, Agresja: {Agresja}, Life Steal: {LifeSteal}, APRes: {APRes}, ADRes: {ADRes}");
    }
}

public interface IPostac
{
    string Imie { get; set;  }
    string Klasa { get; set;  }
    double Sila { get; set;  }
    double Mana { get; set;  }
    double HP { get; set;  }
    double Szczescie { get; set;  }
    bool CanAct();
    void WyswietlStaty();
}
 public abstract class PostacDekator : IPostac
    {
        protected IPostac _postac;

        public PostacDekator(IPostac postac)
        {
            _postac = postac;
        }

      
        public virtual string Imie
        {
            get => _postac.Imie;
            set => _postac.Imie = value;  
        }

        public virtual string Klasa
        {
            get => _postac.Klasa;
            set => _postac.Klasa = value;  
        }

        public virtual double Sila
        {
            get => _postac.Sila;
            set => _postac.Sila = value;  
        }

        public virtual double Mana
        {
            get => _postac.Mana;
            set => _postac.Mana = value; 
        }

        public virtual double HP
        {
            get => _postac.HP;
            set => _postac.HP = value;

        }

        public virtual double Szczescie
        {
            get => _postac.Szczescie;
            set => _postac.Szczescie = value; 
        }

    public virtual bool CanAct()
    {
        return _postac.CanAct();
    }

    public virtual void WyswietlStaty()
        {
            _postac.WyswietlStaty();
        }
}

public class PowerBoostDekator : PostacDekator
{
    private double _boostAmount;

    public PowerBoostDekator(IPostac character, double boostAmount) : base(character)
    {
        _boostAmount = boostAmount;
    }

    public override double Sila
    {
        get
        {
            if (_postac is Enemy enemy && enemy.HP < enemy.HP * 0.4)
            {
                return _postac.Sila + _boostAmount;
            }
            return _postac.Sila;
        }
    }

    public override bool CanAct()
    {
        
        return _postac.Mana > 0;
    }

    public override void WyswietlStaty()
    {
        base.WyswietlStaty();
        if (_postac is Enemy enemy && enemy.HP < enemy.HP * 0.4)
        {
            Console.WriteLine($"Agresja: Siła przeciwnika zwiększona o {_boostAmount}");
        }
    }
}