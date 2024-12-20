﻿using ApiDomain.Models;
using ApiDomain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/users")]
    [Produces("application/json")]
    public class UsersController : Controller
    {
        private readonly IUserRepository _service;

        public UsersController(IUserRepository service) => _service = service;

        /// <summary>
        /// Retrieves all users.
        /// </summary>
        /// <returns>All Users.</returns>
        /// <response code="200">Returns all Users.</response>
        [HttpGet]
        public IEnumerable<User> GetAllUsers() => _service.GetAll();

        /// <summary>
        /// Get a specific user by ID.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve</param>
        /// <returns>The user with the specified ID.</returns>
        /// <response code="200">Returns the user with the specified ID.</response>
        /// <response code="404">The user is not found.</response>
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _service.Get(id);
            return user != null ? Ok(user) : NotFound();
        }

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="user">The user object to be created</param>
        /// <returns>The created user.</returns>
        /// <response code="201">The user is successfully added.</response>
        /// <response code="400">The user data is invalid.</response>
        [HttpPost]
        public IActionResult CreateUser(User user) => CreatedAtAction(nameof(GetUser), new { id = user.Id }, _service.Create(user));

        /// <summary>
        /// Updates an existing user.
        /// </summary>
        /// <param name="id">The ID of the user to update.</param>
        /// <param name="updatedUser">The user object containing the updated details.</param>
        /// <returns>The updated user.</returns>
        /// <response code="200">The operation of updating is successful.</response>
        /// <response code="404">The user is not found.</response>
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, User updatedUser)
        {
            var result = _service.Update(id, updatedUser);
            return result ? Ok(result) : NotFound();
        }

        /// <summary>
        /// Deletes a user by its id.
        /// </summary>
        /// <param name="id">The ID of the user delete.</param>
        /// <returns>An IActionResult indicating the result of the operation.</returns>
        /// <response code="204">The user is successfully deleted.</response>
        /// <response code="404">The user is not found.</response>
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id) => _service.Delete(id) ? NoContent() : NotFound();

        /// <summary>
        /// Retrieves the statistics of watched movies for a user by the specified identifier.
        /// </summary>
        /// <param name="id">The ID of the user whose watched movies statistics are being retrieved.</param>
        /// <returns>The statistics of watched movies for a user with specified ID.</returns>
        /// <response code="200">Returns the statistics of watched movies for a user with specified ID.</response>
        /// <response code="404">The user is not found.</response>
        [HttpGet("{id}/statistics")]
        public IActionResult GetStatistics(int id) 
        {
            var statistics = _service.GetMovieStatistics(id);
            return statistics != null ? Ok(statistics) : NotFound();
        } 
    }
}
