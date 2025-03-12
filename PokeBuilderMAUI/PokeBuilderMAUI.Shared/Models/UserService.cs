<<<<<<< Updated upstream
version https://git-lfs.github.com/spec/v1
oid sha256:78417d1e7028d7d4f973be51f5cfc1722f5fd124405e253a07a5d5eefdb19046
size 834
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

        public UserService(IConfiguration configuration)
        {
            _configuration = configuration;

            var connectionString = _configuration.GetConnectionString("DbConnection");
            var mongoUrl = MongoUrl.Create(connectionString);
            var mongoClient = new MongoClient(mongoUrl);
            _database = mongoClient.GetDatabase(mongoUrl.DatabaseName);
        }
        public IMongoDatabase Database => _database;

    }
}
>>>>>>> Stashed changes
