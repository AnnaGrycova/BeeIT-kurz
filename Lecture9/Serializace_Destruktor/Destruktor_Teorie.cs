using System;

namespace Serializace_Destruktor
{
    // tahle trida ma jak konstruktor tak destruktor
    public class Destruktor_Teorie
    {
        // tohle je klasicky konstruktor
        public Destruktor_Teorie()
        {
            Console.WriteLine("Konstruktor");
        }

        // a tohle je naopak destruktor, ktery se zavola pri "niceni" objektu Garbage Collectorem (GC)
        ~Destruktor_Teorie()
        {
            Console.WriteLine("Destruktor");
        }
    }
}
