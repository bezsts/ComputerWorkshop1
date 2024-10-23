using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDomain.Models
{
    public class MovieStatistics
    {
        public int TotalMovies { get; set; }
        public Dictionary<Genre, int> MoviesByGenre { get; set; }

        public MovieStatistics(int watchedMovies, Dictionary<Genre, int> moviesByGenre) 
        {
            TotalMovies = watchedMovies;
            MoviesByGenre = moviesByGenre;
        }
    }
}
