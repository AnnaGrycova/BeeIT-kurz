using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Domaci_Ukol.Contracts
{
    public class Film
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Director { get; set; }
        public int Year { get; set; }

        [XmlIgnore]
        public IList<int> Hodnoceni { get; set; }

        // implementuj prumerne hodnoceni filmu (muzete pouzit "Average")
        public double? PrumerneHodnoceni => Hodnoceni.Any() ? Hodnoceni.Average() : 0.0;

        public Film()
        {
            Hodnoceni = new List<int>();
        }

        public Film(int id, string name, string director, int year) : this()
        {
            ID = id;
            Name = name;
            Director = director;
            Year = year;
        }

        internal object Select(Func<object, object> p)
        {
            throw new NotImplementedException();
        }

        // implementujte metodu ToString nasledovnim spusobem (musi byt stejny jako v metode FilmovaDatabaze.VypisVsechFilmu())
        // ID (5 znaku), Name (30 znaku), Director (20 znaku), Year (8 znaku), PrumerneHodnoceni (10 znaku)
        public override string ToString()
        {
            return $"{ID.ToString().PadRight(4)} {Name.PadRight(29)} {Director.PadRight(19)} {Year.ToString().PadRight(7)} {PrumerneHodnoceni.ToString().PadRight(9)}";
        }

        public void PridejHodnoceni(int hodnoceni)
        {
            Hodnoceni.Add(hodnoceni);
        }
    }
}
