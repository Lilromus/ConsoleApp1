using System;
using System.Collections.Generic;
using System.Numerics;


namespace ConsoleApp4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Produkt> produkty = new List<Produkt>();

            Produkt produkt1 = new Produkt(1, "Harnaś", 3.20);
            Produkt produkt2 = new Produkt(2, "Chleb", 4.20);
            Produkt produkt3 = new Produkt(3, "Mleka", 2.40);

            produkty.Add(produkt1);
            produkty.Add(produkt2);
            produkty.Add(produkt3);

            PokazKoszyk(produkty);
        }

        public static void PokazKoszyk(List<Produkt> produkty)
        {
            foreach (Produkt produkt in produkty)
            {
                Console.WriteLine(produkt);
            }
        }

    }

    class Produkt
    {
        public int ID;
        public string Nazwa;
        public double Cena;


        public Produkt(int ID, string Nazwa, double Cena)
        {
            this.ID = ID;
            this.Nazwa = Nazwa;
            this.Cena = Cena;
        }

        public override string ToString()
        {
            return ID.ToString() +". "+ Nazwa +" "+ Cena.ToString() + "zł";
        }

    }

}
