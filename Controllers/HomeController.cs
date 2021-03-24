using Assignment3.Models;
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

        private IMovieRepository _repository;

        public HomeController(ILogger<HomeController> logger, IMovieRepository repository)
        {
            _logger = logger;
            _repository = repository;
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
        public IActionResult EnterMovie(Movie movie)
        {
            //Make sure the form was filled correctly. Display errors if not.
            if (ModelState.IsValid)
            { 
                return View("MovieList", movie);
            }
            else
            {
                return View();
            }

        }

        //points to the movie list page if the user goes straight to the page without entering a movie to get there
        public IActionResult MovieList()
        {
            return View(TempStorage.Movies);
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
