using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Models
{
                                     //why isnt this turning light green like inheritance normally does.
    public class EFMovieRepository : IMovieRepository
    {
        private MovieSiteDbContext _context;

        public EFMovieRepository (MovieSiteDbContext context)
        {
            _context = context;
        }

        public IQueryable<Movie> Movies => _context.Movies;
    }
}
