using System;
using System.IO;
using System.Text;

namespace IO_Soubory
{
    public class IO_Soubory_Cteni
    {
        private const string exampleFolder = @"..\..\..\Examples";

        public static void SpustiVsechno()
        {
            try
            {
                PrikladCteni();
                PrikladCteniFile();
                PrikladCteniVyjimky();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Konec cteni");
            }
        }

        public static void PrikladCteni()
        {
            using (StreamReader sr = new StreamReader(Path.Combine(exampleFolder, "textak.txt")))
            {
                string radka;
                while ((radka = sr.ReadLine()) != null)
                {
                    Console.WriteLine(radka);
                }
            }
        }

        public static void PrikladCteniFile()
        {
            string[] radky = File.ReadAllLines(Path.Combine(exampleFolder, "test3.txt"));
            foreach (string radka in radky)
            {
                Console.WriteLine(radka);
            }
        }

        public static void PrikladCteniVyjimky()
        {
            try
            {
                using (StreamReader sr = new StreamReader(Path.Combine(exampleFolder, "textak2.txt")))
                {
                    string radka;
                    while ((radka = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(radka);
                    }
                }


                using (FileStream fs = new FileStream(Path.Combine(exampleFolder, "test3.txt"), FileMode.Open, FileAccess.Read))
                using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
                {
                    // vice sofistikovane reseni, v nekterych pripadech pouzitelne
                }
            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException("Soubor neexistuje", ex);
            }
            catch
            {
                throw;
            }
        }
    }
}
