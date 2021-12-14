using System.IO;
using System.Text;

namespace IO_Soubory
{
    public class IO_Soubory_VytvoreniAZapis
    {
        private const string exampleFolder = @"..\..\..\Examples";
        public const string text = "text na ulozeni";

        public static void Vytvoreni()
        {
            // pouzijeme stream
            Stream stream = File.Create(Path.Combine(exampleFolder, "test1.txt"));

            byte[] bytesToSave = Encoding.UTF8.GetBytes(text + "1");

            stream.Write(bytesToSave, 0, bytesToSave.Length);   // zapiseme do streamu
            stream.Flush();                                     // zapiseme do suboru

            stream.Dispose();                                   // uvolnime stream (nespravovany zdroj)
        }

        public static void VytvoreniVyjimky()
        {
            byte[] bytesToSave = Encoding.UTF8.GetBytes(text + "2");

            Stream stream = null;

            try
            {
                stream = File.Create(Path.Combine(exampleFolder, "test1.txt"));
                stream.Write(bytesToSave, 0, bytesToSave.Length);
            }
            finally
            {
                if (stream != null)
                {
                    stream.Dispose();
                }
            }
        }

        public static void VytvoreniUsing()
        {
            byte[] bytesToSave = Encoding.UTF8.GetBytes(text + "3");

            using (FileStream stream = File.Create(Path.Combine(exampleFolder, "test2.txt")))
            {
                stream.Write(bytesToSave, 0, bytesToSave.Length);
            }
        }

        public static void VytvoreniPomociStreamWriteru()
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(exampleFolder, "test3.txt")))
            {
                sw.WriteLine("prvni radek");
            }
        }

        public static void AppendNewLine()
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(exampleFolder, "test3.txt"), true))
            {
                sw.WriteLine("druhy radek");
                sw.WriteLine("treti radek");
            }
        }

        public static void AppendKomplexni()
        {
            using (FileStream fs = new FileStream(Path.Combine(exampleFolder, "test3.txt"), FileMode.Append, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
            {
                sw.WriteLine("ctvrty radek");
                sw.WriteLine("paty radek");
                sw.WriteLine("sesty radek");
            }
        }
    }
}
