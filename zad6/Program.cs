using System;
using System.Collections.Generic;
using System.Linq;

namespace zad6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Tworzenie Dazy Danych Produktów LINQem
            var produktData = new[]
            {
                new { ID = 1, Nazwa = "Harnaś", Cena = 3.20 },
                new { ID = 2, Nazwa = "Chleb", Cena = 4.20 },
                new { ID = 3, Nazwa = "Mleko", Cena = 2.40 },
                new { ID = 4, Nazwa = "Masło", Cena = 5.00 },
                new { ID = 5, Nazwa = "Cukier", Cena = 3.50 }
            };

           
            List<Produkt> produkty = produktData
               .Select(p => new Produkt(p.ID, p.Nazwa, p.Cena))  
               .ToList();

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

   
    public class Produkt
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
            return $"{ID}. {Nazwa} {Cena:0.00} zł";
        }
    }
}
