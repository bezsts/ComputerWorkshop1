using ApiDomain.Models;
using ApiDomain.Storage;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UserController : Controller
    {
        private readonly IUserStorage storage;

        public UserController(IUserStorage storage) => this.storage = storage;

        /// <summary>
        /// Returns all users
        /// </summary>
        /// <returns>Users</returns>
        [HttpGet(Name = "GetAllUsers")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public IEnumerable<User> GetAll() => storage.GetAll();

        /// <summary>
        /// Returns a user for an id specified
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>User</returns>
        /// <response code="200">Returns the user.</response>
        /// <response code="404">The user is not found.</response>
        [HttpGet("{id}", Name = "GetUserById")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public IActionResult Get(int id)
        {
            var user = storage.Get(id);
            return user != null ? Ok(user) : NotFound();
        }

        /// <summary>
        /// Adds a new user to the storage
        /// </summary>
        /// <param name="user">The user object to be added</param>
        /// <returns>The result of the add operation</returns>
        /// <response code="201">The user is successfully added.</response>
        /// <response code="400">The user data is invalid.</response>
        [HttpPost(Name = "AddUser")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public IActionResult Post(User user) => CreatedAtAction(nameof(Get), new { id = user.Id }, storage.Add(user));

        /// <summary>
        /// Updates an existing user by id and new user data
        /// </summary>
        /// <param name="id">Id of the user to be updated</param>
        /// <param name="updatedUser">The new user data</param>
        /// <returns>The result of the update operation</returns>
        /// <response code="200">The operation of updating is successful.</response>
        /// <response code="404">The user is not found.</response>
        [HttpPut("{id}", Name = "UpdateUserById")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public IActionResult Put(int id, User updatedUser)
        {
            var result = storage.Update(id, updatedUser);
            return result ? Ok(result) : NotFound();
        }

        /// <summary>
        /// Deletes a user from the storage by id
        /// </summary>
        /// <param name="id">Id of user to be deleted</param>
        /// <returns>The result of the delete operation</returns>
        /// <response code="204">The user is successfully deleted.</response>
        /// <response code="404">The user with the specified id does not exist</response>
        [HttpDelete("{id}", Name = "DeleteUserById")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public IActionResult Delete(int id) => storage.Delete(id) == 0 ? NotFound() : NoContent();
    }
}
