using System;

namespace Serializace_Destruktor
{
    public class Serializace_Destruktor_Priklad
    {
        public static void Main(string[] args)
        {
            // Vytvorime objekt "destruktor", cimz zavolame konstruktor tridy Destruktor_Teorie
            var destruktor = new Destruktor_Teorie();

            Console.WriteLine("Hello World");

            // Zavolame Garbage Collector - vynutime si okamzite odstraneni nepotrebnych veci z pameti
            // GC by mel zavolat destruktor objektu "destruktor"
            // !!! Pozor !!! pro vyskouseni je potreba spustit kod v rezimu "Release" namisto "Debug"
            //      V rezimu "Debug" GC neznici objektu "destruktor" v pameti pro pripadne pozdejsi nahlednuti
            //      GC znici objekt v pameti az po ukonceni programu
            GC.Collect();


            Serializace_Teorie.UlozeniDoXml();
            Serializace_Teorie.NacteniZXml();

            //var ukol = new Serializace_Ukol();
            //ukol.PraceSXml();

            Console.ReadLine();
        }
    }
}
