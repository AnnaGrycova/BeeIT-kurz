using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Serializace_Destruktor
{
    public class Serializace_Teorie
    {
        public class XmlPriklad
        {
            public string Jmeno { get; set; }
            public string Prijmeni { get; set; }
        }

        private const string soubor = @"..\..\..\Examples\priklad.xml";

        public static void UlozeniDoXml()
        {
            var seznam = new List<XmlPriklad> 
                { 
                    new XmlPriklad { Jmeno = "Peter", Prijmeni = "Malik" }, 
                    new XmlPriklad { Jmeno = "Marian", Prijmeni = "Kaluza" },
                    new XmlPriklad { Jmeno = "Zdenek", Prijmeni = "Vais" }
                };

            // nejdrive si vytvorime Serializer
            XmlSerializer serializer = new XmlSerializer(seznam.GetType());
            // pak klasicky vytvorime StreamWriter
            using (StreamWriter sw = new StreamWriter(soubor))
            {
                serializer.Serialize(sw, seznam);
            }

            Console.WriteLine("Skontroluj soubor \\Examples\\priklad.xml");
        }

        public static void NacteniZXml()
        {
            if (File.Exists(soubor))
            {
                var seznam = new List<XmlPriklad>();
                XmlSerializer serializer = new XmlSerializer(seznam.GetType());
                using (StreamReader sr = new StreamReader(soubor))
                {
                    seznam = (List<XmlPriklad>)serializer.Deserialize(sr);
                }

                Console.WriteLine("Obsah souboru \\Examples\\priklad.xml :");
                foreach (var item in seznam)
                {
                    Console.WriteLine($"Jmeno: {item.Jmeno}\t\tPrijmeni: {item.Prijmeni}");
                }
            }
            else
            {
                throw new FileNotFoundException($"Zadany soubor {soubor} neexistuje.");
            }
        }
    }
}
