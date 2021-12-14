using Domaci_Ukol.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Domaci_Ukol.FD
{
    class FilmovaDatabazeXml : FilmovaDatabaze
    {
        public FilmovaDatabazeXml(string souborFilmy, string souborHodnoceni)
            : base(souborFilmy, souborHodnoceni) { }

        // uloz vsechny filmy z interniho seznamu "Filmy" do souboru
        // hint:  pouzijte XmlSerializer a jeho metodu Serialize
        // hint2: StreamWriter bude taky potreba
        // hint3: Nezapomente ulozit taky Hodnoceni do jineho souboru
        // hint4: Pro ulozeni hodnoceni si musite nejdriv vytvorit seznam hodnoceni
        public override void UlozFilmy()
        {
            throw new NotImplementedException();
        }

        // nacti vsechny filmy ze souboru do interniho seznamu Filmy
        // hint:  pouzijte XmlSerializer a jeho metodu Deserialize
        // hint2: StreamReader
        // hint3: nactete hodnoceni do seznamu List<HodnoceniFilmu>
        // hint4: vyuzijte metodu "PridejHodnoceniFilmu" pro prirazeni hodnoceni ze souboru k filmum
        // hint5: Osetrete neexistenci souboru
        public override void NactiFilmy()
        {
            throw new NotImplementedException();
        }
    }
}
