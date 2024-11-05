using ConsoleApp1;
using System;
using System.Net.NetworkInformation;


public class Program
{
    public static void Main(string[] args)
    {
        Figura trapez = new Trapez(2, 4, 3, 1, 3);
        Console.WriteLine($"Pole Trapezu: {trapez.ObliczPole()}, Obwód Trapezu: {trapez.ObliczObwod()}\n");
        Figura romb = new Romb(3, 4);
        Console.WriteLine($"Pole Rombu: {romb.ObliczPole()}, Obwód Rombu: {romb.ObliczObwod()}\n");
        Figura prostokat = new Prostokat(6, 4);
        Console.WriteLine($"Pole Prostokąt: {prostokat.ObliczPole()}, Obwód Prostokąta: {prostokat.ObliczObwod()}");
    }
}
