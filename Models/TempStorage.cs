using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Models
{
    public class TempStorage
    {
        private static List<MovieModel> movies = new List<MovieModel>();

        public static IEnumerable<MovieModel> Movies => movies;

        public static void AddMovie(MovieModel movie)
        {
            movies.Add(movie);
        }
    }
}
