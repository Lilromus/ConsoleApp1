using System;
using ConsoleApp3;

public class Program
{
    public static void Main(string[] args)
    {
        SystemBankowy konto = new SystemBankowy("12345678901", 500);
        Console.WriteLine($"Początkowe saldo: {konto.Saldo} zł");

        bool petla = true;

        while(petla)
        {
            Console.WriteLine("\nWybierz operację:");
            Console.WriteLine("1. Wpłata");
            Console.WriteLine("2. Wypłata");
            Console.WriteLine("3. Lokata");
            Console.WriteLine("4. Wyświetl saldo");
            Console.WriteLine("5. Zamknij aplikację");

            Console.WriteLine("Wpisz wybór");

            string wybor = Console.ReadLine();

            switch(wybor)
            {
                case "1":
                    Console.WriteLine("Podaj kwotę do wpłaty: ");
                    double kwota_wplata = Convert.ToDouble(Console.ReadLine());
                    konto.Wplac(kwota_wplata);
                    break;
                case "2":
                    Console.WriteLine("Podaj kwotę do wypłaty: ");
                    double kwota_wyplaty = Convert.ToDouble(Console.ReadLine());
                    konto.Wyplac(kwota_wyplaty);
                    break;
                case "3":
                    konto.Lokata();
                    break;
                case "4":
                    Console.WriteLine($"Aktualne stan konta: {konto.Saldo} zl");
                    break;
                case "5":
                    Console.WriteLine("Zamykam aplikacje!!!!");
                    petla = false;
                    break;
                default:
                    Console.WriteLine("Musisz wybór podać!!!!");
                    break;
            }
        }

    }
}
