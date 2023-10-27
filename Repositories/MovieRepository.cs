using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using WebAPITestBE.DBContext;
using WebAPITestBE.IRepositories;

namespace WebAPITestBE.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDBContext _db;

        public MovieRepository(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task<Movie> AddMovie(Movie movie)
        {
            _db.Movie.Add(movie);
            await _db.SaveChangesAsync();

            return movie;
        }

        public async Task<bool> DeleteMovie(int id)
        {
            _db.Movie.RemoveRange(_db.Movie.Where(x => x.ID == id));
            int rowDel = await _db.SaveChangesAsync();
            return rowDel > 0;
        }

        public async Task<List<Movie>> GetAllMovie()
        {
            return await _db.Movie.ToListAsync();
        }

        public async Task<Movie?> GetFilteredMovieByID(int id)
        {
            return await _db.Movie.FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<Movie?> GetFilteredMovieByTitle(string title)
        {
            return await _db.Movie.FirstOrDefaultAsync(x => x.Title == title);
        }

        public async Task UpdateMovie(int id, JsonPatchDocument movies)
        {
            var mov = await _db.Movie.FirstOrDefaultAsync(x => x.ID == id);
            if (mov != null)
            {
                movies.ApplyTo(mov);
                await _db.SaveChangesAsync();
            }
        }
    }
}
