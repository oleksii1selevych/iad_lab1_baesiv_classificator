using BaesovClassificator.Entities.Domain;
using Microsoft.EntityFrameworkCore;

namespace BaesovClassificator.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Result>? Results { get; set; }
        public DbSet<WordDescription>? Words { get; set; }
        public DbSet<Classification> Classifications { get; set; }
    }
}
