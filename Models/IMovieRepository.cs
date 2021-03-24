using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Models
{
    //Interface called IMovieRepository
    public interface IMovieRepository
    {
        //IQueryable of Movie
        IQueryable<Movie> Movies { get; }
    }
}
