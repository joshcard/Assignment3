﻿using Assignment3.Models;
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

        //private instance of the DbContext
        private MovieSiteDbContext _context { get; set; }
        
        //private instance of the IMovieRepository
        private IMovieRepository _repository;

        //Controller
        public HomeController(ILogger<HomeController> logger, IMovieRepository repository, MovieSiteDbContext ctx)
        {
            _logger = logger;
            _repository = repository;
            _context = ctx;
        }

        //Action for the index page
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
                //Add the inputted movie to the database
                _context.Movies.Add(movie);
                _context.SaveChanges();
                return View("MovieList", _repository.Movies);
            }
                return View(movie);

        }

        //points to the movie list page if the user goes straight to the page without entering a movie to get there
        public IActionResult MovieList()
        {
            return View(_repository.Movies);
        }

        //Action for deleting a movie
        public IActionResult DeleteMovie(int movieId)
        {
            //create the instance of a Movie and set it equal to the movie that was selected
            Movie movieDelete = _context.Movies.Where(x => x.MovieId == movieId).FirstOrDefault();

            //remove it from the database
            _context.Movies.Remove(movieDelete);
            _context.SaveChanges();

            return View("MovieList", _repository.Movies);
        }

        //Action for the Edit movie page
        [HttpGet]
        public IActionResult EditMovie(int Id)
        {
            //Create an instance of a Movie and set it equal to the movie they selected so that the edit form
            //gets auto populated with data
            Movie tempMovie = _context.Movies.Where(x => x.MovieId == Id).FirstOrDefault();
            return View(tempMovie);
        }

        //Action for Editing a movie
        [HttpPost]
        public IActionResult EditMovie(Movie movie)
        {
            //ensure the inputs are valid
            if (ModelState.IsValid)
            {
                //instance of a Movie set equal to the movie that was selected
                Movie movieUpdate = _context.Movies.Where(x => x.MovieId == movie.MovieId).FirstOrDefault();

                //Update all the info from the user form
                movieUpdate.Category = movie.Category;
                movieUpdate.Title = movie.Title;
                movieUpdate.Year = movie.Year;
                movieUpdate.Director = movie.Director;
                movieUpdate.Rating = movie.Rating;
                movieUpdate.Edited = movie.Edited;
                movieUpdate.LentTo = movie.LentTo;
                movieUpdate.Notes = movie.Notes;

                _context.SaveChanges();

                return View("MovieList", _repository.Movies);

            }
            else
            {
                return View(movie);
            }
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
