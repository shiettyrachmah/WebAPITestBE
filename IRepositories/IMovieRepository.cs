using Microsoft.AspNetCore.JsonPatch;
using WebAPITestBE.DBContext;

namespace WebAPITestBE.IRepositories
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetAllMovie();
        Task<Movie?> GetFilteredMovieByID(int id);
        Task<Movie?> GetFilteredMovieByTitle(string title);
        Task<Movie> AddMovie(Movie movie);
        Task UpdateMovie(int id, JsonPatchDocument movies);
        Task<bool> DeleteMovie(int id);
    }
}
