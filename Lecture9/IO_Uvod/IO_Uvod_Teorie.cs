using System.Collections.Generic;
using System.IO;

namespace IO_Uvod
{
    public class IO_Uvod_Teorie
    {
        // Dejme tomu, ze je nas projekt ulozen v PC ve slozce - C:\BeeIT\Lekce08\IO_Uvod\
        // Absolutni cesta - C:\BeeIT\Lekce08\IO_Uvod\Soubory\soubor.txt
        // Relativni cesta - Soubory\soubor.txt (pro vyssi uroven pouzijeme ..\)
        public static void Trida_Path()
        {
            string fileName = Path.GetFileName(@"c:\aaa\bbb\textak.txt");                   // textak.txt
            string fileName2 = Path.GetFileNameWithoutExtension(@"c:\aaa\bbb\textak.txt");  // textak

            string directoryName = Path.GetDirectoryName(@"c:\aaa\bbb\");                   // c:\aaa\bbb
            string directoryName2 = Path.GetDirectoryName(@"c:\aaa\bbb\textak.txt");        // c:\aaa\bbb

            string folderName = Path.GetFileName(@"c:\aaa\bbb");                            // bbb
            string folderName2 = Path.GetFileName(@"c:\aaa\bbb\");                          // ""

            string fullPath = Path.GetFullPath(@"..\..\..\Examples");                       // absolutni cesta k "Examples" directory

            // pouzivame pro spravny "vypocet" cesty, bez ohledu na Directory separator
            string combine = Path.Combine(@"c:\aaa", "textak.txt");                         // c:\aaa\textak.txt
            string combine2 = Path.Combine(@"c:\aaa\", "textak.txt");                       // c:\aaa\textak.txt

            // dalsi spusob jak zjistit cestu ke slozce
            string cesta = @"c:\aaa\bbb\";
            if (cesta.EndsWith(Path.DirectorySeparatorChar.ToString()))                     // directory separator "\"
            {
                cesta = cesta.Substring(0, cesta.Length - 1);                               // c:\aaa\bbb
            }
        }

        public static void Trida_Directory()
        {
            // zjistime aktualni slozku
            string currentDirectory = Directory.GetCurrentDirectory();

            if (!currentDirectory.Equals(@"C:\BeeIT\"))
            {
                // nastavuje aktualni slozku
                Directory.SetCurrentDirectory(@"C:\BeeIT\");
            }

            IEnumerable<string> directories = null;
            string[] files = null;

            // zjistime jestli slozka existuje
            if (Directory.Exists(currentDirectory))
            {
                // Seznam vsech podslozek
                //directories = Directory.EnumerateDirectories(currentDirectory);
                directories = Directory.GetDirectories(currentDirectory);

                // seznam vsech souboru
                //files = Directory.EnumerateFiles(currentDirectory).ToArray();
                files = Directory.GetFiles(currentDirectory);

                // Enumerate umoznuje pracovat se seznamem predtim nez jsou vraceny vsechny hodnoty
            }
            else
            {
                // Vytvor slozku
                Directory.CreateDirectory(currentDirectory);
            }

            Directory.Move(@"C:\BeeIT\", @"D:\BeeIT\");

            Directory.Delete(@"C:\BeeIT\");
        }

        public static void Trida_File()
        {
            string source = Path.Combine(@"C:\BeeIT", "textak.txt");
            string target = Path.Combine(@"C:\BeeIT", "textak.txt");

            if (File.Exists(source))
            {
                // skopirujeme textak do target
                File.Copy(source, target);
            }

            // presunieme textak do target
            File.Move(source, target);

            // vymazeme textak
            File.Delete(target);
        }
    }
}
