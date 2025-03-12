<<<<<<< HEAD
version https://git-lfs.github.com/spec/v1
oid sha256:2053c71492de7453c52f902acfaaa214fb4d686d78813427b4ba4c4342d25a8d
size 271
=======
﻿using Microsoft.AspNetCore.Mvc;
using PokeBuilderMAUI.Shared.Services;
using PokeBuilderMAUI.Shared.ViewModels;
using PokeBuilderMAUI.Shared.Models;
using MongoDB.Bson;
using MongoDB.Driver;


namespace PokeBuilderMAUI.Shared.Controllers
{
    [ApiController]
    [Route("api")]
    public class UserController : ControllerBase
    {
        private readonly IMongoCollection<User> _users;

        public UserController(UserService userService)
        {
            _users = userService.Database.GetCollection<User>("UserInformationStorage");
        }

        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await _users.Find(FilterDefinition<User>.Empty).ToListAsync();
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<User>> GetByUsername(string username)
        {
            var filter = Builders<User>.Filter.Eq(x => x.Username, username);
            var user = _users.Find(filter).FirstOrDefault();
            return user is not null ? Ok(user) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Create(User newUser)
        {
            await _users.InsertOneAsync(newUser);
            return CreatedAtAction(nameof(GetByUsername), new { username = newUser.Username }, newUser);
        }

        [HttpPut("{username}")]
        public async Task<ActionResult> Update(User updatedUser, string password)
        {
            var filter = Builders<User>.Filter.Eq(x => x.Username, updatedUser.Username);
            await _users.ReplaceOneAsync(filter, updatedUser);
            return Ok();
        }

        [HttpDelete("{username}")]
        public async Task<ActionResult> Delete(string username)
        {
            var filter = Builders<User>.Filter.Eq(x => x.Username, username);
            await _users.DeleteOneAsync(filter);
            return Ok();

        }
    }
}
>>>>>>> 9b4ef72 (fixed github)
