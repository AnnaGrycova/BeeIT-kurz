using Domaci_Ukol.Contracts;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System;

namespace Domaci_Ukol.FD
{
    public class FilmovaDatabazeCsv : FilmovaDatabaze
    {
        public FilmovaDatabazeCsv(string souborFilmy, string souborHodnoceni) 
            : base(souborFilmy, souborHodnoceni) { }

        // uloz vsechny filmy z interniho seznamu Filmy do souboru (ID;Name;Director;Year)
        // hint: pouzij funkci: string = string.Join(";" string[])
        // hint2: pouzij StreamWriter a jeho metodu WriteLine(string)
        // hint3: nezapomente na ulozeni hodnoceni do dalsiho souboru
        public override void UlozFilmy()
        {
            using (StreamWriter sw = new StreamWriter(@"..\..\..\Examples\Data\filmy.csv", false))
            {
                foreach (var f in Filmy)
                {
                    string[] hodnoty = { f.ID.ToString(), f.Director, f.Year.ToString() };
                    string radek = String.Join(";", hodnoty);
                    sw.WriteLine(radek);
                }
            }

            using (StreamWriter sw = new StreamWriter(@"..\..\..\Examples\Data\hodnoceni.csv", true))
            {
                foreach (var f in Filmy)
                {
                    foreach (var h in f.Hodnoceni)
                    {
                        string[] values = { f.ID.ToString(), h.ToString() };
                        string row = String.Join(";", values);
                        sw.WriteLine(row);
                    }                    
                }
            }
        }

        // nacti vsechny filmy z CSV souboru do interniho seznamu Filmy
        // hint: pouzij StreamReader a jeho metodu ReadLine(), ktera vrati null kdyz prijde na konec souboru
        // hint2: pouzij string[] = string.Split(';') pro ziskani hodnot z radku
        // hint3: nezapomente taky nacist soubor hodnoceni
        // hint4: vyuzijte metodu "PridejHodnoceniFilmu" pro prirazeni hodnoceni ze souboru k filmum
        // hint5: Osetrete neexistenci souboru
        public override void NactiFilmy()
        {
            try
            {
                using (var reader = new StreamReader(@"..\..\..\Examples\Data\filmy.csv"))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] values = line.Split(';');

                        Filmy.Add(new Film(int.Parse(values[0]), values[1], values[2], int.Parse(values[3])));
                    }
                }

                using (var reader = new StreamReader(@"..\..\..\Examples\Data\hodnoceni.csv"))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        string[] values = line.Split(';');

                        PridejHodnoceniFilmu(int.Parse(values[0]), int.Parse(values[1]));
                    }
                }
            }
            catch (FileNotFoundException)
            {

                throw;
            }

        }
    }
}
