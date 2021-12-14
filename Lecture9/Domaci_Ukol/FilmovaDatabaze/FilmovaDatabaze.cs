using Domaci_Ukol.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using Domaci_Ukol.Contracts;

namespace Domaci_Ukol.FD
{
    public abstract class FilmovaDatabaze
    {
        // seznam vsech filmu
        protected List<Film> Filmy { get; set; }
        protected string NazevSouboruProFilmy { get; set; }
        protected string NazevSouboruProHodnoceni { get; set; }

        // konstruktor
        public FilmovaDatabaze(string souborFilmy, string souborHodnoceni)
        {
            Filmy = new List<Film>();
            NazevSouboruProFilmy = souborFilmy;
            NazevSouboruProHodnoceni = souborHodnoceni;
        }

        // implementujte metodu PridejFilm
        // prida novy film do seznamu "Filmy"
        // zaroven v pripade "id == 0" zjisti nejvyssi dosavadni ID v seznamu a novemu filmu priradi tohle ID+1
        // pozor na pripad kdy pridavame prvni film
        public void PridejFilm(string jmeno, string reziser, int rokVydani, int id = 0)
        {
            if (Filmy.Any())                
            {
                id = Filmy.Last().ID + 1;
            }
            else
            {
                id = 1;
            }
            Filmy.Add(new Film(id, jmeno, reziser, rokVydani));
        }

        // implementujte metodu OdeberFilm
        // odebe film se zadanym ID ze seznamu
        // vyhodte KeyNotFoundException pokud film se zadanym ID neexistuje
        public void OdeberFilm(int id)
        {
            try
            {
                Filmy.Remove(Filmy.Where(x => x.ID == id).First());
            }
            catch (KeyNotFoundException e)
            {

                Console.WriteLine($"Exception caught: {e.Message}"); 
            }
        }

        // jednoducha metoda, ktera vraci vsechny Filmy
        public IEnumerable<Film> VsechnyFilmy()
        {
            return Filmy;
        }

        // implementujte metodu VypisVsechFilmu
        // tato metoda vypise hlavicku (naimplementovano) a pak postupne vsechny filmy ze seznamu (ToString())
        public void VypisVsechFilmu()
        {
            if (Filmy.Any())
            {
                Console.WriteLine("ID   Jmeno                         Reziser             Rok     Hodnoceni");
                foreach (var film in Filmy)
                {
                    Console.WriteLine(film.ToString());
                }
            }
            else
            {
                Console.WriteLine("Zatim zde nejsou zadne filmy.");
            }
        }

        // implementujte metodu PridejHodnoceniFilmu
        // Pridejte hodnoceni filmu se zadanym ID
        // v pripade, ze film se zadanym ID neexistujte vyhodte KeyNotFoundException
        public void PridejHodnoceniFilmu(int id, int hodnoceni)
        {
            try
            {
                Filmy.Where(x => x.ID == id).First().PridejHodnoceni(hodnoceni);
            }
            catch (KeyNotFoundException e)
            {

                Console.WriteLine($"Exception caught: {e.Message}");
            }
        }

        // tyhle dve metody implementujte v souborech FilmovaDatabazeXml.cs a FilmovaDatabazeCsv.cs
        public abstract void UlozFilmy();
        public abstract void NactiFilmy();
    }
}
