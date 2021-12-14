using System;

namespace Serializace_Destruktor.Contracts
{
    [Serializable]
    public class Mesto
    {
        public string Jmeno { get; set; }
        public int PocetObyvatel { get; set; }
    }
}
