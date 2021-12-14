using System.IO;

namespace IO_Uvod
{
    public class IO_Uvod_Ukol
    {
        public static void VytvorBackupSlozky()
        {
            string source = @"..\..\..\Examples";
            string target = @"..\..\..\Examples_Backup";

            VytvorBackup(source, target);
        }

        // Vytvorte metodu, ktera bude na vstupu mit slozku, ktere chceme udelat back-up
        // druhym parametrem je slozka do ktere skopirujeme vsechny slozky, podslozky a soubory v rovnake hierarchii
        // napriklad Examples slozka bude po dodelani backupu pristupna v Examples_Backup
        // hint:  muzete pouzit rekurzi pro vytvoreni backup podslozek
        // hint2: Directory.GetFiles a Directory.GetDirectories, File.Copy
        private static void VytvorBackup(string source, string target)
        {
            // Vas kod
        }
    }
}
