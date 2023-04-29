using Microsoft.EntityFrameworkCore;

namespace P2_2020CC605.Models
{
    public class covidDBContext : DbContext
    {
        public covidDBContext(DbContextOptions options) : base(options) { 
        
        }

        public DbSet<departamentos> departamentos { get; set; }
        public DbSet<generos> generos { get; set; }
        public DbSet<casosreportados> casosreportados { get; set; }
    }
}
