using Microsoft.EntityFrameworkCore;

namespace WebAPITestBE.DBContext
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<Movie> Movie { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>().ToTable("Movie");

            //seed data to table movie from datajson
            string dataJson = System.IO.File.ReadAllText("DataSeedMovies.json");

            List<Movie> movies = System.Text.Json.JsonSerializer.Deserialize<List<Movie>>(dataJson);

            foreach (Movie itemMovie in movies)
            {
                modelBuilder.Entity<Movie>().HasData(itemMovie);
            }
        }
    }
}
