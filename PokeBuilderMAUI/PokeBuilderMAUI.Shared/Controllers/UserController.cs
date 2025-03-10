using Microsoft.AspNetCore.Mvc;
using PokeBuilderMAUI.Shared.Services;
using PokeBuilderMAUI.Shared.ViewModels;
using PokeBuilderMAUI.Shared.Models;
using MongoDB.Bson;

namespace PokeBuilderMAUI.Shared.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<List<User>> Get() =>
            await _userService.GetAsync();

        [HttpGet("{username}")]
        public async Task<ActionResult<User?>> Get(string username)
        {
            var user = await _userService.GetAsync(username);

            return user;
        }

        [HttpPost]
        public async Task<IActionResult> Create(User newUser)
        {
            await _userService.CreateAsync(newUser);
            CreatedAtActionResult cr = new CreatedAtActionResult(nameof(Get), "UserController", new { username = newUser.Username }, newUser);
            return cr;
        }

        [HttpPut("{username}")]
        public async Task<IActionResult> Update(User updatedUser, string password)
        {
            var user = await _userService.GetAsync(password);

            updatedUser.Password = user.Password;

            await _userService.UpdateAsync(user, password);
            NoContentResult nc = new NoContentResult();
            return nc;
        }

        [HttpDelete("{username}")]
        public async Task<IActionResult> Delete(ObjectId id)
        {
            var user = await _userService.GetAsync(id);

            await _userService.RemoveAsync(id);
            NoContentResult nc = new NoContentResult();
            return nc;
        }
    }
}