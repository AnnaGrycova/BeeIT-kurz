using System;

namespace VyvolaniVyjimky
{
    public class VyvolaniVyjimky_Teorie
    {
        // ukazka pouziti "throw" - takzvane vyhozeni vyjimky
        private static void VyvolaniVyjimky(int cislo)
        {
            if (cislo < 0)
            {
                throw new ArithmeticException("Cislo je zaporne.");
            }
        }

        private static void PrvniVyjimka()
        {
            try
            {
                DruhaVyjimka();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static void DruhaVyjimka()
        {
            try
            {
                PosledniVyjimka();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static void PosledniVyjimka()
        {
            throw new Exception("Posledni vyjimka.");
        }

        public static void ZnovuvyhozeniVyjimky()
        {
            try
            {
                PrvniVyjimka();
            }
            catch (Exception e)
            {
                Console.WriteLine("Znovu vyhozeni:");
                Console.WriteLine($"Exception: {e}");           // muzeme pouzit taky e.ToString()
                Console.WriteLine($"Message: {e.Message}");
            }
        }

        /*
         * Pri pouziti jenom "throw;" zustava zachovany call stack (StackTrace)
         */

        private static void PrvniVyjimkaRetezeni()
        {
            try
            {
                DruhaVyjimkaRetezeni();
            }
            catch (Exception e)
            {
                throw new Exception("Prvni vyjimka.", e);
            }
        }

        private static void DruhaVyjimkaRetezeni()
        {
            try
            {
                PosledniVyjimka();
            }
            catch (Exception e)
            {
                throw new Exception("Druha vyjimka.", e);
            }
        }

        public static void RetezeniVyjimek()
        {
            try
            {
                PrvniVyjimkaRetezeni();
            }
            catch (Exception e)
            {
                Console.WriteLine("Retezeni:");
                Console.WriteLine($"Exception: {e}");           // muzeme pouzit taky e.ToString()
                Console.WriteLine($"Message: {e.Message}");
            }
        }

        /*
         * Pri vyhozeni nove vyjimky stack trace zacina od mista vyhozeni (tedy catch block)
         * Pri predani puvodni vyjimky je pak tato vyjimka dostupna v InnerException
         * Predava se informace o puvodni chybe, Message obsahuje posledni vyhozenou vyjimku
         * pouziva se napr. pri zabalovani puvodnich do vlastnich vyjimek
         */
    }
}
