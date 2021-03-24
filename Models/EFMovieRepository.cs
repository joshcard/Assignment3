using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Models
{
    //Class that inherits from IMovieRepository
    public class EFMovieRepository : IMovieRepository
    {
        //Private instance of MovieSiteDbContext
        private MovieSiteDbContext _context;

        //Constructor
        public EFMovieRepository (MovieSiteDbContext context)
        {
            _context = context;
        }

        //IQueryable instance of Movie
        public IQueryable<Movie> Movies => _context.Movies;
    }
}
