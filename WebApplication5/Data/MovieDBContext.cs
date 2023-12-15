using Microsoft.EntityFrameworkCore;
using WebApplication5.Entities;

namespace WebApplication5.Data
{
    public class MovieDBContext:DbContext
    {
        public MovieDBContext(DbContextOptions<MovieDBContext> opt) : base(opt) { }

        public DbSet<Movie> Movies { get; set; }
    }
}
