using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class SystemBankowy
    {
        public string NumerKonta;
        public double Saldo;

        public SystemBankowy(string numerKonta, double saldo_poczatek = 0)
        {
            this.NumerKonta = numerKonta;
            this.Saldo = saldo_poczatek;
        }

        public void Wplac(double kwota)
        {
            if (kwota <= 0)
            {
                Console.WriteLine("Kwota wpłaty musi być większa od 0");
                return;
            }
            else
            {
                Saldo += kwota;
                Console.WriteLine($"Wpłacono: {kwota}zł. Zostało ci na koncie: {Saldo}zł");
            }
        }

        public void Wyplac(double kwota)
        {
            if (kwota <= 0)
            {
                Console.WriteLine("Kwota wypłaty musi być większa od 0");
                return;
            }

            if (kwota > Saldo)
            {
                Console.WriteLine("Niewystarczająco środków na koncie");
                return;
            }

            Saldo -= kwota;
            Console.WriteLine($"Wypłacono: {kwota} zł, Zostało ci na koncie {Saldo} zł");
        }

        public void Lokata()
        {
            double zysk = Saldo * 0.05;
            Saldo += zysk;
            Console.WriteLine($"Lokata!!!!. Zysk: {zysk} zł, Zostało ci na koncie {Saldo} zł");
        }
    }
}