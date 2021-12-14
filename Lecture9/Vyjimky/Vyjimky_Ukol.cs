using System;

namespace Vyjimky
{
    public class Vyjimky_Ukol
    {
        public static void VyjimkyUkol()
        {
            ConvertToDoubleAndWrite("neni cislo");
            ConvertToDoubleAndWrite("5.987654321-6");
            ConvertToDoubleAndWrite(DateTime.Now);
            ConvertToDoubleAndWrite("1.8E308");
            ConvertToDoubleAndWrite("7.98");

            //double cislo = GetDouble();
            //Console.WriteLine($"Zadane cislo: {cislo}");
        }

        // Metoda vypise originalni objekt, prekonvertovany objekt na double a pak odradkuje
        // Upravte metodu tak aby jste osetrili vsechny mozne problemy a vypiste
        // 1) nespravne zadane cislo - "neni cislo" , "5.987654321-6"       FormatException
        // 2) prilis velike cislo    - "1.8E308"                            OverflowException
        // Nezapomente na osetreni jinych chyb (napriklad konverze datumu)
        private static void ConvertToDoubleAndWrite(object o)
        {
            Console.WriteLine($"Original text: {o.ToString()}");

            Console.WriteLine(Convert.ToDouble(o));

            Console.WriteLine();
        }

        // Vytvorte metodu, ktera vrati zadane desetinne cislo
        // pouzijte Convert.ToDouble(), try/catch
        // v pripade chybne zadaneho cisla pokus opakujte dokud neni zadane spravne cislo
        // Otestovat lze zavolanim metody v Main a vypsanim cisla
        public static double GetDouble()
        {
            Console.Write("Zadej desetinne cislo: ");

            double cislo = 0;
            
            // Vas kod

            return cislo;
        }
    }
}
