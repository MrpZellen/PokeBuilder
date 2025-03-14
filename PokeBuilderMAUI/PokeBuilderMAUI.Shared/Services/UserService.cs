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
>>>>>>> 9b4ef72 (fixed github)
