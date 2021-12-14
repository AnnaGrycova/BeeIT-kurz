using System;

namespace VyvolaniVyjimky.MojeVyjimky
{
    public class MojeNovaException : Exception
    {
        public MojeNovaException() : base() { }

        public MojeNovaException(string message) : base(message) { }

        public MojeNovaException(string message, Exception exception) : base(message, exception) { }

        public override string ToString()
        {
            return $"Moje vlastni vyjimka: {Message}";
        }
    }
}
