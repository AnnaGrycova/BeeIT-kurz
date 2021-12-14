using System;
using System.Collections.Generic;
using System.Linq;

namespace VyvolaniVyjimky
{
    public class VyvolaniVyjimky_Ukol
    {
        public static void VyvolaniVyjimkyUkol()
        {
            PrumerneHodnoceni();
        }

        // vytvorte metodu, ktera nacte zadane cislo (napr. int.Parse)
        // pokud neni hodnoceni v rozsahu min-max, prosim vyhodte ArithmeticException
        private static int ZadejHodnoceniVDanemRozsahu(int min, int max)
        {
            Console.Write("Zadej hodnoceni: ");
            int hodnoceni = int.Parse(Console.ReadLine());
            
            // Vas kod

            return hodnoceni;
        }

        // Zadavej hodnoceni dokud neni zadano spravne cislo a v uvedenem rozsahu (nekonecna smycka)
        // pouzijte prosim try/catch a FormatException pro odchyceni nespravne zadaneho cisla
        public static int ZadejHodnoceni(int min, int max)
        {
            return ZadejHodnoceniVDanemRozsahu(min, max);
        }

        // Vytvorte metodu, ktera 5x zavola metodu ZadejHodnoceni a pak vypise prumerne hodnoceni
        // rozsah min a max si muzete urcit jak chcete, v reseni bude pouzito 1-5 (jako CSFD)
        // vicero moznosti implemntace
        private static void PrumerneHodnoceni()
        {
            Console.WriteLine($"Prumerne hodnoceni je: ");
        }
    }
}
