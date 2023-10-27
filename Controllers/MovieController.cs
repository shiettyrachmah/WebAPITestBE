using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAPITestBE.DBContext;
using WebAPITestBE.IServices;

namespace WebAPITestBE.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly ILogger<MovieController> _logger;

        private readonly IMovieServices _services;

        public MovieController(ILogger<MovieController> logger, IMovieServices services)
        {
            _logger = logger;
            _services = services;
        }

        [HttpGet]
        public async Task<ActionResult<List<Movie>>> GetData()
        {
            try
            {
                var resultData = await _services.GetAllMovie();
                if (resultData.Count == 0)
                {
                    return NotFound(new { message = "Data Empty" });
                }

                return Ok(resultData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/{id}")]
        public async Task<ActionResult<Movie>> GetFilteredMovieByID(int id)
        {
            try
            {
                var resultData = await _services.GetFilteredMovieByID(id);
                if (resultData == null)
                {
                    return NotFound(new { message = "Data Not Found" });
                }

                return Ok(resultData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> AddData([FromForm] string jsonData)
        {
            try
            {
                var data = JsonConvert.DeserializeObject<Movie>(jsonData);

                var resultData = await _services.AddMovie(data);

                if (resultData == null)
                {
                    return NotFound(new { message = "Add Unsuccessfully. Title Movie was Exist" });
                }

                return Ok(resultData);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("/{id}")]
        public async Task<ActionResult> DelData(int id)
        {
            try
            {
                bool resultData = await _services.DeleteMovie(id);

                if (resultData == false)
                {
                    return NotFound(new { message = "Delete Unsuccessfully. Movie ID Not Found" });
                }
                else
                {
                    return Ok(new { message = "Delete Movie From Database" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPatch("/{id}")]
        public async Task<ActionResult<Movie>> UpdateMoviePatch(int id, [FromBody] JsonPatchDocument patchMovie)
        {
            try
            {
                var resultData = await _services.UpdateMovie(id, patchMovie);
                if (resultData == null)
                {
                    return Ok(new { message = "Update Unsuccessfully. Movie ID Not Found" });
                }
                return Ok(resultData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
