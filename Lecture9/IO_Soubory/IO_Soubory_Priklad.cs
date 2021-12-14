using System;

namespace IO_Soubory
{
    public class IO_Soubory_Priklad
    {
        public static void Main(string[] args)
        {
            // vytvoreni a zapis
            IO_Soubory_VytvoreniAZapis.Vytvoreni();
            IO_Soubory_VytvoreniAZapis.VytvoreniVyjimky();
            IO_Soubory_VytvoreniAZapis.VytvoreniUsing();
            IO_Soubory_VytvoreniAZapis.VytvoreniPomociStreamWriteru();
            IO_Soubory_VytvoreniAZapis.AppendNewLine();
            IO_Soubory_VytvoreniAZapis.AppendKomplexni();
            Console.WriteLine("Konec zapisu");

            // Cteni
            try
            {
                IO_Soubory_Cteni.PrikladCteni();
                IO_Soubory_Cteni.PrikladCteniFile();
                IO_Soubory_Cteni.PrikladCteniVyjimky();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Konec cteni");
            }

            //var ukol = new IO_Soubory_Ukol();
            //ukol.PraceSeSoubory();

            Console.ReadLine();
        }
    }
}
