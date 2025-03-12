using MongoDB.Driver;

namespace PokeLoginApi.Data
{
    public class MongoDbService
    {
        private readonly IConfiguration configuration;
        private readonly IMongoDatabase? mongoDatabase;

        public MongoDbService(IConfiguration configuration)
        {
            this.configuration = configuration;
            var client = new MongoClient(configuration.GetConnectionString("MongoDb"));
            mongoDatabase = client.GetDatabase("UserInformationStorage");
        }

        public IMongoDatabase? database => mongoDatabase;
    }
}
