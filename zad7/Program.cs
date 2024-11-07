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
                new { ID = 1, Nazwa = "Harnaś", Cena = 3.20, Kategorie =  "Alkohol" },
                new { ID = 2, Nazwa = "Chleb", Cena = 4.20, Kategorie = "Chlebowe" },
                new { ID = 3, Nazwa = "Mleko", Cena = 2.40 , Kategorie = "Mleczny"},
                new { ID = 4, Nazwa = "Masło", Cena = 5.00 , Kategorie = "Mleczny"},
                new { ID = 5, Nazwa = "Cukier", Cena = 3.50 , Kategorie = "Słodkie"},
                new { ID = 6, Nazwa = "Soplica", Cena = 12.50, Kategorie = "Alkohol"},
                new { ID = 7, Nazwa = "Kroasan", Cena = 1.50, Kategorie = "Chlebowe"}
            };


            List<Produkt> produkty = produktData
               .Select(p => new Produkt(p.ID, p.Nazwa, p.Cena, p.Kategorie)).ToList();


            
            PokazKoszyk(produkty);
            Console.WriteLine("\n");

            Console.WriteLine("Produkty posortowanie: \n");
            var ProduktyPosortowane = Sortowanie(produkty);
            PokazKoszyk(ProduktyPosortowane);
            Console.WriteLine("\n");


            Console.WriteLine("Produkty z kategorii Alkohol: \n");
            var produktyAlkohol = Filtrowanie(produkty, "Alkohol");
            PokazKoszyk(produktyAlkohol);
            Console.WriteLine("\n");

            Console.WriteLine("Produkty z kategorii Mleczny: \n");
            var produktyMleczne = Filtrowanie(produkty, "Mleczny");
            PokazKoszyk (produktyMleczne);
            Console.WriteLine("\n");

            Console.WriteLine("Produkty z kategorii Chlebowe: \n");
            var produktyChlebowe = Filtrowanie(produkty, "Chlebowe");
            PokazKoszyk(produktyChlebowe);
            Console.WriteLine("\n");

            Console.WriteLine("Produkty z kategorii Słodkie: \n");
            var produktySlodkie = Filtrowanie(produkty, "Słodkie");
            PokazKoszyk(produktySlodkie);
            Console.WriteLine("\n");


        }


        //Pokazywanie Koszyku
        public static void PokazKoszyk(List<Produkt> produkty)
        {
            foreach (Produkt produkt in produkty)
            {
                Console.WriteLine(produkt);
            }
        }

        //Sortowanie według cen

        public static List<Produkt> Sortowanie(List<Produkt> produkty) 
        {
            return produkty.OrderByDescending(p => p.Cena).ToList();
        }

        //Filtrowanie według kategorii

        public static List<Produkt> Filtrowanie(List<Produkt> produkty, string kategoria)
        {
            return produkty.Where(p => p.Kategorie.Equals(kategoria, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }


    public class Produkt
    {
        public int ID;
        public string Nazwa;
        public double Cena;
        public string Kategorie;

        public Produkt(int ID, string Nazwa, double Cena, string Kategorie)
        {
            this.ID = ID;
            this.Nazwa = Nazwa;
            this.Cena = Cena;
            this.Kategorie = Kategorie;
        }

        public override string ToString()
        {
            return $"{ID}. {Nazwa} {Cena:0.00} zł Kategoria: {Kategorie}";
        }
    }
}
