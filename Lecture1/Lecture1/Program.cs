using System.IO;
using System;

namespace Lecture1 //jmenny prostor odpovida nazvu projektu
{
    class Program
    {
        static void Main(string[] args)
        {
            double vyskaVCentimetrech = ZjistiVstup("Zadej vysku v cm:");
            double vyskaVMetrech = prevedCentimetryNaMetry(vyskaVCentimetrech);
            double vaha = ZjistiVstup("Zadej vahu v kg:");
            Console.WriteLine($"Tve BMI ti pravi: {VypoctiBMI(vaha, vyskaVMetrech)}");

            static string VypoctiBMI(double vaha, double vyska)
            {
                double bmi = vaha / (vyska * vyska);
                if (bmi < 18.5)
                {
                    return "podvaha";
                }
                if (bmi >= 18.5 && bmi <= 24.9)
                {
                    return "norma";
                }
                else
                {
                    return "obezita";
                }
            }

        static double ZjistiVstup(string zprava)
            {
                double promenna;
                Console.WriteLine($"{zprava}");
                string userInput = Console.ReadLine();
                if (!double.TryParse(userInput, out promenna))
                {
                    Console.WriteLine("Nevalidni vstup.");
                }
                return promenna;
            }

        static double prevedCentimetryNaMetry(double vyskaVCentimetrech)
            {
                return vyskaVCentimetrech / 100;
            }
        }

        public static bool JeRovnostranny(float a, float b, float c) => a == b && b == c;
        
        public static bool? JeRovnoramenny(float a, float b, float c)
        {
            //return (a == b && b == c) || (a == b && a == c) || (b == c && a == c);
            return null;
        }

        public static bool JeMozneSestavitTrojuhelnik(float a, float b, float c)
        {
            return (c < a + b) && (b < a + c) && (a < b + c);
        }

        //vychozi hodnota enumu je prvni hodnota, proto se na prvni misto casto dava None, Unspecified
        //flags
        // jednou / nebo & - bitovy operator, porovnava na urovni bitu
        //inkrementace, rozdil mezi ++i a i++
        //podminky muzu psat na jeden radek
        //if (4 > 2) Console.WriteLine("dsf");
        //defenzivni programovani - zadavat defaultni hodnotu, nebo vyhodime vyjimku podle pravidla Fail Fast
        //pokud stich prilis dlouhy, je dobre pouzit treba slovnik (ten ale zabira dost mista v pameti)

        public int? VypoctiBMI(int vyska, int vaha)
        {
            return null;
        }




    }
}
