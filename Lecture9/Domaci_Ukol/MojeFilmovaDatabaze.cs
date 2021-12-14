using System;
using Domaci_Ukol.FD;
using VyvolaniVyjimky;

namespace Domaci_Ukol
{
    public class MojeFilmovaDatabaze
    {
        // zde muzete upravit cesty pro jednotlive soubory
        private const string filmyCsv = @"..\..\..\Examples\Data\filmy.csv";
        private const string hodnoceniCsv = @"..\..\..\Examples\Data\hodnoceni.csv";
        private const string filmyXml = @"..\..\..\Examples\Data\filmy.xml";
        private const string hodnoceniXml = @"..\..\..\Examples\Data\hodnoceni.xml";

        // Samotna filmova databaze
        private FilmovaDatabaze Database { get; set; }

        // vyber mezi nactenim z XML nebo CSV
        public MojeFilmovaDatabaze()
        {
            try
            {
                int volba = 0;
                while (!(volba == 1 || volba == 2))
                {
                    Console.Write("Vyber prosim nacteni z XML(1) nebo CSV(2): ");
                    int.TryParse(Console.ReadLine(), out volba);
                }

                if (volba == 1)
                {
                    Database = new FilmovaDatabazeXml(filmyXml, hodnoceniXml);
                }

                if (volba == 2)
                {
                    Database = new FilmovaDatabazeCsv(filmyCsv, hodnoceniCsv);
                }

                Database.NactiFilmy();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Chyba pri nacteni filmu: {ex.Message}");
            }
        }

        // Vyber moznosti operaci nad databazi
        // 1 - vypis vsech filmu
        // 2 - pridani noveho filmu do databaze
        // 3 - odebrani filmu z databaze
        // 4 - Pridani hodnoceni filmu
        // 5 - ulozeni vsech filmu do souboru (XML nebo CSV, zalezi na rozhodnuti na zacatku programu)
        // 9 - Ukonceni programu
        // 0 - Vycisteni konzole
        public void Run()
        {
            Console.WriteLine("-------------------------------------------------------");
            bool end = false;
            while (!end)
            {
                VypisMoznosti();

                char key = Console.ReadKey(true).KeyChar;
                switch(key)
                {
                    case '1':
                        VypisVsechnyFilmy();
                        break;
                    case '2':
                        PridejFilm();
                        break;
                    case '3':
                        OdeberFilm();
                        break;
                    case '4':
                        PridejHodnoceni();
                        break;
                    case '5':
                        UlozFilmy();
                        break;
                    case '9':
                        end = true;
                        break;
                    case '0':
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Neplatny prikaz, skus znovu");
                        break;
                }
                Console.WriteLine("-------------------------------------------------------");
            }
        }

        // Vypis jednotlivych moznosti operaci nad databazi
        private void VypisMoznosti()
        {
            Console.WriteLine(@"Vypis vsech filmu    :   1");
            Console.WriteLine(@"Pridej film          :   2");
            Console.WriteLine(@"Odeber film          :   3");
            Console.WriteLine(@"Pridej hodnoceni     :   4");
            Console.WriteLine(@"Ulozeni filmu        :   5");
            Console.WriteLine(@"Ukonceni             :   9");
            Console.WriteLine(@"Vymaz konzoli        :   0");
            Console.WriteLine("-------------------------------------------------------");
        }

        // Vypis vsech filmu
        private void VypisVsechnyFilmy()
        {
            try
            {
                Database.VypisVsechFilmu();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Chyba pri vypisu filmu: {ex.Message}");
            }
        }

        // pridani filmu do databaze
        private void PridejFilm()
        {
            try
            {
                Console.Write("Zadej jmeno : ");
                string jmeno = Console.ReadLine();
                Console.Write("Zadej rezisera : ");
                string reziser = Console.ReadLine();
                Console.Write("Zadej rok vydani : ");
                int rok = int.Parse(Console.ReadLine());
                Database.PridejFilm(jmeno, reziser, rok);
                Console.WriteLine("Film uspesne pridany.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Chyba pri pridani filmu: {ex.Message}");
            }
        }

        // odebrani filmu z databaze
        private void OdeberFilm()
        {
            try
            {
                Console.Write("Zadej ID filmu pro odebrani : ");
                int id = int.Parse(Console.ReadLine());
                Database.OdeberFilm(id);
                Console.WriteLine("Film uspesne odebrany.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Chyba pri odebirani filmu: {ex.Message}");
            }
        }

        // pridani hodnoceni filmu
        private void PridejHodnoceni()
        {
            try
            {
                Console.Write("Zadej ID filmu pro hodnoceni : ");
                int id = int.Parse(Console.ReadLine());
                int hodnoceni = VyvolaniVyjimky_Ukol.ZadejHodnoceni(1, 5);
                Database.PridejHodnoceniFilmu(id, hodnoceni);
                Console.WriteLine($"Hodnoceni pridano filmu {id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Chyba pri hodnoceni filmu: {ex.Message}");
            }
        }

        // ulozeni filmu do souboru
        private void UlozFilmy()
        {
            try
            {
                Database.UlozFilmy();
                Console.WriteLine($"Filmy ulozeny do souboru.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Chyba pri ulozeni filmu: {ex.Message}");
            }
        }
    }
}
