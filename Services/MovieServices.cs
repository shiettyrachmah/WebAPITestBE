using Microsoft.AspNetCore.JsonPatch;
using WebAPITestBE.DBContext;
using WebAPITestBE.IRepositories;
using WebAPITestBE.IServices;

namespace WebAPITestBE.Services
{
    public class MovieServices : IMovieServices
    {
        private readonly IMovieRepository _repo;
        public MovieServices(IMovieRepository repo)
        {
            _repo = repo;
        }
        public async Task<Movie> AddMovie(Movie obj)
        {
            Movie? checkDataTitleExist = await _repo.GetFilteredMovieByTitle(obj.Title);

            if (checkDataTitleExist == null)
            {
                Movie movies = new Movie()
                {
                    Title = obj.Title,
                    Description = obj.Description,
                    Image = obj.Image,
                    Rating = obj.Rating,
                    CreatedAt = obj.CreatedAt,
                    UpdatedAt = obj.UpdatedAt
                };

                await _repo.AddMovie(movies);

                checkDataTitleExist = movies;
            }
            else
            {
                return null;
            }

            return checkDataTitleExist;
        }

        public async Task<bool> DeleteMovie(int id)
        {
            if (await _repo.GetFilteredMovieByID(id) != null)
                return await _repo.DeleteMovie(id);

            return false;

        }

        public async Task<List<Movie>> GetAllMovie()
        {
            return await _repo.GetAllMovie();
        }

        public async Task<Movie?> GetFilteredMovieByID(int id)
        {
            return await _repo.GetFilteredMovieByID(id);
        }

        public async Task<Movie> UpdateMovie(int id, JsonPatchDocument movie)
        {
            Movie? movNewData = await _repo.GetFilteredMovieByID(id);

            if (movNewData != null)
            {
                await _repo.UpdateMovie(id, movie);
            }
            else
            {
                return null;
            }

            return movNewData;
        }

    }
}
