<<<<<<< HEAD
version https://git-lfs.github.com/spec/v1
oid sha256:d60a2a511596656d1356e7f3f03149be277a317d6ddcbb9c3e693027f1e73457
size 988
=======
﻿using MongoDB.Driver;
using PokeBuilderMAUI.Shared.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using Microsoft.Extensions.Configuration;

namespace PokeBuilderMAUI.Shared.Services
{
    public class UserService
    {
        private readonly IConfiguration _configuration;
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<User> _userCollection;

        public UserService(IConfiguration configuration)
        {
            _configuration = configuration;

            var connectionString = _configuration.GetConnectionString("DbConnection");
            var mongoUrl = MongoUrl.Create(connectionString);
            var mongoClient = new MongoClient(mongoUrl);
            _database = mongoClient.GetDatabase(mongoUrl.DatabaseName);

            // MongoDB collection for users
            _userCollection = _database.GetCollection<User>("UserInformationStorage");
        }
        public IMongoDatabase Database => _database;

        public async Task<List<User>> GetUsersAsync()
        {
            return await _userCollection.Find(FilterDefinition<User>.Empty).ToListAsync();
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Username, username);
            return await _userCollection.Find(filter).FirstOrDefaultAsync();
        }
    }
}
>>>>>>> 9b4ef72 (fixed github)
