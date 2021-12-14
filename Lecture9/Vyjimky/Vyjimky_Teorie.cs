using System;

namespace Vyjimky
{
    public class Vyjimky_Teorie
    {
        private static readonly int x = 5;
        private static readonly int y = 0;

        // neosetreni vyjimky
        public static void NeosetrenaVyjimka(int x, int y)
        {
            Console.WriteLine(x / y);
            /* 
             * program by v tomhle bode spadnul s generickou neosetrenou chybou "DividedByZeroException"
             *
             * Unhandled Exception: System.DivideByZeroException: Attempted to divide by zero.
             *       at Vyjimky.NeosetrenaVyjimka() in C:\...\Vyjimky_Teorie.cs:line 13
             */
        }

        // osetreni vstupu pomoci podminky
        public static void KlasickeOsetreniVstupu(int x, int y)
        {
            if (y == 0)
            {
                Console.WriteLine("Nulou nelze delit.");
                return;
            }
            Console.WriteLine(x / y);

            /* 
             * program by vypsal vysledek nebo chybovou hlasku
             * nasledne by korektne skoncil
             */
        }

        // osetreni vstupu pomoci zachyceni vyjimek
        public static void OsetreniPomociVyjimky(int x, int y)
        {
            try
            {
                Console.WriteLine(x / y);       
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Nulou nelze delit.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Nastala chyba v programu: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Konec programu deleni.");
            }

            /* 
             * program by vypsal vysledek nebo chybovou hlasku
             * pak by vypsal Konec programu deleni
             * nasledne by korektne skoncil
             */
        }
    }
}
