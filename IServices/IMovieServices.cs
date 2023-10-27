using Microsoft.AspNetCore.JsonPatch;
using WebAPITestBE.DBContext;

namespace WebAPITestBE.IServices
{
    public interface IMovieServices
    {
        Task<List<Movie>> GetAllMovie();
        Task<Movie?> GetFilteredMovieByID(int id);
        Task<Movie> AddMovie(Movie movie);
        Task<Movie> UpdateMovie(int id, JsonPatchDocument movie);
        Task<bool> DeleteMovie(int id);
    }
}
