using Microsoft.AspNetCore.Mvc;
using PokeBuilderMAUI.Shared.Services;
using PokeBuilderMAUI.Shared.ViewModels;
using System.Web.Mvc;
using PokeBuilderMAUI.Shared.Models;

namespace PokeBuilderMAUI.Shared.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Add()
        {
            return (IActionResult)View();
        }
        [HttpPost]
        public IActionResult Add(UserAddViewModel userAddViewModel)
        {
            if (ModelState.IsValid)
            {
                User newUser = new User
                {
                    Username = userAddViewModel.User.Username,
                    Password = userAddViewModel.User.Password
                };

                _userService.AddUser(newUser);
                return (IActionResult)RedirectToAction("Home");
            }
            return (IActionResult)View(userAddViewModel);
        }
        public IActionResult Delete(string id)
        {
            if(id == null)
            {
                return (IActionResult)RedirectToAction("Home");
            }

            var selectedUser = _userService.GetUser(id);
            return (IActionResult)View(selectedUser);
        }
        [HttpPost]
        public IActionResult Delete(User user)
        {
            if(user.Id == null)
            {
                return (IActionResult)RedirectToAction("Home");
            }
            _userService.DeleteUser(user.Username);
            return (IActionResult)RedirectToAction("Home");
        }

    }
}
