using Serializace_Destruktor.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Serializace_Destruktor
{
    public class Serializace_Ukol
    {
        private const string soubor = @"..\..\..\Examples\Mesta.xml";
        protected List<Mesto> Mesta { get; set; }

        // vytvoreni seznamu mest
        public Serializace_Ukol()
        {
            Mesta = new List<Mesto>
            {
                new Mesto { Jmeno = "Praha", PocetObyvatel = 1324277 },
                new Mesto { Jmeno = "Brno", PocetObyvatel = 381346 },
                new Mesto { Jmeno = "Ostrava", PocetObyvatel = 287968}
            };
        }

        // kontrolni metoda pro overeni spravnosti implementace
        public void PraceSXml()
        {
            try
            {
                Console.WriteLine($"Pocet mest v seznamu: {Mesta.Count}");              // 3
                VytvoreniXmlSouboru();
                Mesta.Clear();
                Console.WriteLine("Ulozeni mest do souboru a vycisteni seznamu.");
                Console.WriteLine($"Pocet mest v seznamu: {Mesta.Count}");              // 0

                NacteniXmlSouboru();
                Console.WriteLine("Nacteni mest ze souboru.");
                Console.WriteLine($"Pocet mest v seznamu: {Mesta.Count}");              // 3
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Chyba v programu: {ex.Message}");
            }
        }

        // Vytvorte metodu, ktera ulozi obsah seznamu "Mesta" do Mesta.xml (promenna soubor)
        private void VytvoreniXmlSouboru()
        {
            // Vas kod
        }

        // Vytvorte metodu, ktera nacte soubor Mesta.xml (promenna soubor) do pripraveneho seznamu "Mesta"
        // Pokud soubor neexistuje vyhodte vyjimku FileNotFoundException
        private void NacteniXmlSouboru()
        {
            // Vas kod
        }
    }
}
