using MongoDB.Driver;
using PokeBuilderMAUI.Shared.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;

namespace PokeBuilderMAUI.Shared.Services
{
    public class UserService : IUserService
    {
        private readonly IMongoCollection<User> _users;

        public UserService(IOptions<MongoDBSettings> dbContext)
        {
            var mongoClient = new MongoClient(dbContext.Value.AtlasURI);
            var mongoDatabase = mongoClient.GetDatabase(dbContext.Value.DatabaseName);
            _users = mongoDatabase.GetCollection<User>(dbContext.Value.CollectionName);
        }

        public async Task<List<User>> GetAsync() =>
            await _users.Find(user => true).ToListAsync();

        public async Task<User?> GetAsync(string username) =>
            await _users.Find(user => user.Username == username).FirstOrDefaultAsync();

        public async Task<User?> GetAsync(ObjectId id) =>
            await _users.Find(user => user.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(User newUser) =>
            await _users.InsertOneAsync(newUser);

        public async Task UpdateAsync(User user, string userName) =>
            await _users.ReplaceOneAsync(u => u.Username == userName, user);

        public async Task RemoveAsync(string userName) =>
            await _users.DeleteOneAsync(u => u.Username == userName);

        public async Task RemoveAsync(ObjectId id) =>
            await _users.DeleteOneAsync(u => u.Id == id);
    }
}