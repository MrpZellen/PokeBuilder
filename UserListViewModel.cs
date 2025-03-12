using PokeBuilderMAUI.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeBuilderMAUI.Shared.ViewModels
{
    internal class UserListViewModel
    {
        IEnumerable<User> Users { get; set; }
    }
}
