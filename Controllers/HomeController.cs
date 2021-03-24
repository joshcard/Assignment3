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

        private MovieSiteDbContext context { get; set; }
        
        private IMovieRepository _repository;

        public HomeController(ILogger<HomeController> logger, IMovieRepository repository, MovieSiteDbContext ctx)
        {
            _logger = logger;
            _repository = repository;
            context = ctx;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Points to the MyPodcasts page
        public IActionResult MyPodcasts()
        {
            return View();
        }
        
        //for a GET request on the EnterMovie page
        [HttpGet]
        public IActionResult EnterMovie()
        {
            return View();
        }

        //for a POST on the EnterMovie page
        //once the form is inputted it takes the user to the movie list page and 
        //displays the movies available as well as the movie they just entered
        [HttpPost]
        public IActionResult EnterMovie(Movie movie, IEnumerable<Movie> movies)
        {
            var result = context.Movies.SingleOrDefault(m => m.MovieId == movie.MovieId);

            /*if (result != null)
            {
                context.SaveChanges();
            }*/

            //Make sure the form was filled correctly. Display errors if not.
            if (ModelState.IsValid)
            {
                context.Add(movie);
                context.SaveChanges();
                movies = context.Movies;
                return View("MovieList", movies);
            }
            else
            {
                return View();
            }

        }

        //points to the movie list page if the user goes straight to the page without entering a movie to get there
        public IActionResult MovieList(IEnumerable<Movie> movies)
        {

            return View(movies = context.Movies);
        }

        [HttpPost]
        public IActionResult DeleteMovie(long movieId, IEnumerable<Movie> movies)
        {
            context.Movies.Remove(context.Movies.First(m =>
                m.MovieId == movieId));

            context.SaveChanges();

            movies = context.Movies;
            return View("MovieList", movies );
        }

        [HttpGet]
        public IActionResult EditMovie(Movie movie)
        {
            ViewBag.MovieCategory = movie.Category;
            ViewBag.MovieTitle = movie.Title;
            ViewBag.MovieYear = movie.Year;
            ViewBag.MovieDirector = movie.Director;
            ViewBag.MovieRating = movie.Rating;
            ViewBag.MovieEdited = movie.Edited;
            ViewBag.MovieLentTo = movie.LentTo;
            ViewBag.MovieNotes = movie.Notes;

            return View(movie);
        }

        [HttpPost]
        public IActionResult EditMovie()
        {
            return View();
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
