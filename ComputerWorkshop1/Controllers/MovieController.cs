using ApiDomain.Models;
using ApiDomain.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class MovieController : Controller
    {
        private readonly MovieStorage storage;

        public MovieController(MovieStorage storage)
        {
            this.storage = storage;
        }

        /// <summary>
        /// Returns all movies
        /// </summary>
        /// <returns>Movies</returns>
        [HttpGet(Name = "GetAllMovies")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public IEnumerable<Movie> GetAll() => storage.GetAll();

        /// <summary>
        /// Returns a movie for an id specified
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Movie</returns>
        /// <response code="200">Returns the movie.</response>
        /// <response code="404">The movie is not found.</response>
        [HttpGet("{id}", Name = "GetMovieById")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public IActionResult Get(int id)
        {
            var movie = storage.Get(id);
            return movie == null ? NotFound() : Ok(movie);
        }

        /// <summary>
        /// Adds a new movie to the storage
        /// </summary>
        /// <param name="movie">The movie object to be added</param>
        /// <returns>The result of the add operation</returns>
        /// <response code="201">The movie is successfully added.</response>
        /// <response code="400">The movie data is invalid.</response>
        [HttpPost(Name = "AddMovie")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public IActionResult Post(Movie movie) => CreatedAtAction(nameof(Get), new { id = movie.Id }, storage.Add(movie));

        /// <summary>
        /// Updates an existing movie by id and new movie data
        /// </summary>
        /// <param name="id">Id of the movie to be updated</param>
        /// <param name="updatedMovie">The new movie data</param>
        /// <returns>The result of the update operation</returns>
        /// <response code="200">The operation of updating is successful.</response>
        /// <response code="404">The movie is not found.</response>
        [HttpPut("{id}", Name = "UpdateMovieById")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public IActionResult Put(int id, Movie updatedMovie)
        {
            var result = storage.Update(id, updatedMovie);
            return result ? Ok(result) : NotFound();
        }

        /// <summary>
        /// Deletes a movie from the storage by id
        /// </summary>
        /// <param name="id">Id of movie to be deleted</param>
        /// <returns>The result of the delete operation</returns>
        /// <response code="204">The movie is successfully deleted.</response>
        /// <response code="404">The movie with the specified id does not exist</response>
        [HttpDelete("{id}", Name = "DeleteMovieById")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public IActionResult Delete(int id) => storage.Delete(id) == 0 ? NotFound() : NoContent();
    }
}
