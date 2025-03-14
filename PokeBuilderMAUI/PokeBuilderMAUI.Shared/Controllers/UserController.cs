using Microsoft.AspNetCore.Mvc;
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
        public User currentUser { get; private set; }
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

        [HttpPost("addTeam")]
        public async Task<ActionResult> AddTeamToUser(Pokemon[] pokemons)
        {
            if (currentUser is null)
            {
                return Unauthorized();
            }
            else
            {
                var filter = Builders<User>.Filter.Eq(x => x.Username, currentUser.Username);
                var user = _users.Find(filter).FirstOrDefault();
                user.Teams.Add(pokemons);
                await _users.ReplaceOneAsync(filter, user);
                return Ok();
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(User user)
        {
            var filter = Builders<User>.Filter.Eq(x => x.Username, user.Username);
            var userInDb = _users.Find(filter).FirstOrDefault();
            if (userInDb is null)
            {
                return NotFound();
            }
            if (userInDb.Password != user.Password)
            {
                return Unauthorized();
            }
            currentUser = userInDb;
            return Ok();
        }

        [HttpPost("logout")]
        public async Task<ActionResult> Logout()
        {
            currentUser = null;
            return Ok();
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