using System;
using ConsoleApp2;

public class Program
{
    public static void Main(string[] args)
    {
        SystemBankowy konto = new SystemBankowy("12345678901", 500);
        konto.Wplac(300);

        konto.Wyplac(500);

        konto.Lokata();

    }
}
