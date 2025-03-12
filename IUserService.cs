using MongoDB.Bson;
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
        public Task<List<User>> GetAsync();
        public Task<User?> GetAsync(string username);
        public Task<User?> GetAsync(ObjectId id);
        public Task CreateAsync(User newUser);
        public Task UpdateAsync(User user, string userName);
        public Task RemoveAsync(string userName);
        public Task RemoveAsync(ObjectId id);

    }
}