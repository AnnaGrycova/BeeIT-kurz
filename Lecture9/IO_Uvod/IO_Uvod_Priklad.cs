using System;
using System.IO;

namespace IO_Uvod
{
    public class IO_Uvod_Priklad
    {
        private const string exampleFolder = @"..\..\..\Examples";
        private const string source = @"..\..\..\Examples\Source";
        private const string target = @"..\..\..\Examples\Target";

        public static void Main(string[] args)
        {
            FileAndDirectoryExamples();

            //IO_Uvod_Ukol.VytvorBackupSlozky();

            Console.ReadLine();
        }

        private static void FileAndDirectoryExamples()
        {
            // vytvorime si zdrojovou slozku
            if (!Directory.Exists(source))
            {
                Directory.CreateDirectory(source);
            }

            // vytvorime si cilovou slozku
            if (!Directory.Exists(target))
            {
                Directory.CreateDirectory(target);
            }

            if (Directory.Exists(exampleFolder))
            {
                Console.WriteLine("Seznam pod-slozek:");
                foreach (var folder in Directory.GetDirectories(exampleFolder))
                {
                    Console.WriteLine(folder);
                }

                Console.WriteLine("Seznam souboru:");
                foreach (var file in Directory.EnumerateFiles(exampleFolder))
                {
                    Console.WriteLine(file);
                }

                if (File.Exists(Path.Combine(exampleFolder, "textak.txt")))
                {
                    // skopirujeme textak do source
                    File.Copy(Path.Combine(exampleFolder, "textak.txt"), Path.Combine(source, "textak.txt"));
                }

                // presuneme textak do target
                File.Move(Path.Combine(source, "textak.txt"), Path.Combine(target, "textak.txt"));

                // vymazeme textak
                File.Delete(Path.Combine(target, "textak.txt"));
            }
            else
            {
                Console.WriteLine("Examples slozka neexistuje");
            }

            Directory.Delete(source);
            Directory.Delete(target);
        }
    }
}
