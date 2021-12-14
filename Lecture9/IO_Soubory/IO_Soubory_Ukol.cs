using System;
using System.Collections.Generic;
using System.IO;

namespace IO_Soubory
{
    public class IO_Soubory_Ukol
    {
        private const string soubor = @"..\..\..\Examples\Mesta.csv";
        protected Dictionary<string, int> Mesta { get; set; }

        public IO_Soubory_Ukol()
        {
            Mesta = new Dictionary<string, int>
            {
                { "Praha", 1324277 },
                { "Brno", 381346 },
                { "Ostrava", 287968}
            };
        }

        // Metoda, ktera vytvori soubor Mesta.csv a pak z neho nacte hodnoty
        public void PraceSeSoubory()
        {
            try
            {
                Console.WriteLine($"Pocet mest v seznamu: {Mesta.Count}");              // 3
                VytvoreniSouboru();
                Mesta.Clear();
                Console.WriteLine("Ulozeni mest do souboru a vycisteni seznamu.");
                Console.WriteLine($"Pocet mest v seznamu: {Mesta.Count}");              // 0

                NacteniSouboru();
                Console.WriteLine("Nacteni mest ze souboru.");
                Console.WriteLine($"Pocet mest v seznamu: {Mesta.Count}");              // 3
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Chyba v programu: {ex.Message}");
            }
        }

        // Vytvorte metodu, ktera vytvori soubor Mesta.csv (promenna soubor)
        // a vlozi do nej seznam mest ve formatu CSV : "mesto;pocetObyvatel"
        private void VytvoreniSouboru()
        {
            // Vas kod
        }

        // Vytvorte metodu, ktera nacte soubor Mesta.csv (promenna soubor) do seznamu "Mesta"
        // Pokud soubor neexistuje vyhodte vyjimku FileNotFoundException
        private void NacteniSouboru()
        {
            // Vas kod
        }
    }
}
