using MongoDB.Driver;
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