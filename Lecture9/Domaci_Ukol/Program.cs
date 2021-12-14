using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaci_Ukol
{
    public class Program
    {
        // Main metoda jednoduche filmove databaze
        public static void Main(string[] args)
        {
            var databaze = new MojeFilmovaDatabaze();
            databaze.Run();
        }
    }
}
