using Microsoft.EntityFrameworkCore;
using SuperHeroAPI_DotNet7.Models;

namespace SuperHeroAPI_DotNet7.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Character> Character => Set<Character>();
    }
}
