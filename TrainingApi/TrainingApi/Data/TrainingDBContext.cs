using Microsoft.EntityFrameworkCore;
using TrainingApi.Module.Domain;

namespace TrainingApi.Data
{
    public class TrainingDBContext : DbContext
    {
        public TrainingDBContext(DbContextOptions<TrainingDBContext> options) : base(options) { 

        }

        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<Walkdifficulity> WalkDifficulty { get; set; }
    }
}
