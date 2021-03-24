using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Models
{
    //MovieSiteDbContext class that inherits from DbContext
    public class MovieSiteDbContext : DbContext
    {
        //Constructor
        public MovieSiteDbContext (DbContextOptions<MovieSiteDbContext> options) : base(options)
        {

        }

        //DbSet (table) called Movies
        public DbSet<Movie> Movies { get; set; }
    }
}
