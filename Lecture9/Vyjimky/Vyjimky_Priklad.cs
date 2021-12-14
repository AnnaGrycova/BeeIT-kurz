using System;

namespace Vyjimky
{
    public class Vyjimky_Priklad
    {
        public static void Main(string[] args)
        {
            Priklad();

            //Vyjimky_Ukol.VyjimkyUkol();

            Console.ReadLine();
        }

        private static void Priklad()
        {
            int vysledek = 0;
            try
            {
                Console.Write("Zadej cislo: ");
                int x = int.Parse(Console.ReadLine());
                Console.Write("Zadej delitel: ");
                int y = int.Parse(Console.ReadLine());
                vysledek = x / y;
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Chybne zadane cislo: {ex.ToString()}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Deleni nulou: {ex.Message}");
            }
            catch
            {
                Console.WriteLine($"Chyba pri deleni.");
            }
            finally
            {
                Console.WriteLine(vysledek);
            }
        }
    }
}
