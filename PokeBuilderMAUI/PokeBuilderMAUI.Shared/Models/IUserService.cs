<<<<<<< Updated upstream
version https://git-lfs.github.com/spec/v1
oid sha256:77872571cc3024883a3a1adc9ff029d6b50844efca3c3c199650ef41c34609d2
size 621
=======
﻿using MongoDB.Bson;
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
>>>>>>> Stashed changes
