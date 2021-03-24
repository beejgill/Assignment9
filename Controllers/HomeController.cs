using Assignment3.Models;
using Assignment3.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private MovieDbContext context { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieDbContext cxt)
        {
            _logger = logger;
            context = cxt;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MovieForm(MovieModel movie)
        {
            //TempStorage.AddMovie(movie);
            context.Movies.Add(movie);
            context.SaveChanges();
            return View();
        }

        public IActionResult MovieList()
        {
            return View(new MovieListViewModel
            {
                Movies = context.Movies
            });
            //return View(TempStorage.Movies);
        }

        [HttpPost]
        public IActionResult MovieList(int MovieID, string controllerAction)
        {
            //var movie = context.Movies.Find(MovieID);

            if(controllerAction == "remove")
            {
                var movie = context.Movies.Find(MovieID);
                context.Movies.Remove(movie);
                context.SaveChanges();
                return View(new MovieListViewModel
                {
                    Movies = context.Movies
                });
            }
            else if (controllerAction == "edit")
            {
                var movie = context.Movies.Find(MovieID);
                return View("EditList", movie);
            }
            return View();
        }

        public IActionResult EditList()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EditList(MovieModel movie, int MovieID)
        {
            var movieToEdit = context.Movies.Find(MovieID);
            context.Movies.Remove(movieToEdit);
            context.Movies.Add(movie);
            context.SaveChanges();
            return View("MovieList", new MovieListViewModel
            {
                Movies = context.Movies
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
