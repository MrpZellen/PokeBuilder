using PokeBuilderMAUI.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeBuilderMAUI.Shared.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User? GetUser(string username);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(string username);
    }
}
