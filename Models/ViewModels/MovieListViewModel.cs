using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Models.ViewModels
{
    public class MovieListViewModel
    {
        public IEnumerable<MovieModel> Movies { get; set; }
    }
}
