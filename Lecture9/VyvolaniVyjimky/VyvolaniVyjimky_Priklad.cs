using System;
using VyvolaniVyjimky.MojeVyjimky;

namespace VyvolaniVyjimky
{
    public class VyvolaniVyjimky_Priklad
    {
        public static void Main(string[] args)
        {
            VyvolaniVyjimky_Teorie.ZnovuvyhozeniVyjimky();
            VyvolaniVyjimky_Teorie.RetezeniVyjimek();

            //VyjimkyPriklad();

            //VyvolaniVyjimky_Ukol.VyvolaniVyjimkyUkol();

            Console.ReadLine();
        }

        private static int UrciDelkuTextu(string text)
        {
            if (text == null)
            {
                throw new NullReferenceException("Text je null");
            }

            if (text == string.Empty)
            {
                throw new ArgumentException("Text je prazdny");
            }

            return text.Length;
        }

        private static void DelkaTextu()
        {
            while (true)
            {
                Console.WriteLine("Zacatek Programu.");
                try
                {
                    Console.Write("Zadej text: ");
                    string text = Console.ReadLine();
                    if (text.Equals("null"))
                    {
                        text = null;
                    }
                    Console.WriteLine($"Delka textu je: {UrciDelkuTextu(text)}");
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine("Null reference chyba");
                    throw new MojeNovaException(ex.Message, ex);
                }
                catch
                {
                    Console.WriteLine("Chyba v Programu");
                    throw;
                    // jenom throw zachovava StackTrace, nova vyjimka ma svuj vlastni StackTrace
                }
                finally
                {
                    Console.WriteLine("Konec Programu.");
                }
            }
        }

        private static void VyjimkyPriklad()
        {
            try
            {
                DelkaTextu();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine($"ToString: {ex.ToString()}");
            }
        }
    }
}
