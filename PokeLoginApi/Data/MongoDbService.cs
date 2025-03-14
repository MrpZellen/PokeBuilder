<<<<<<< HEAD
version https://git-lfs.github.com/spec/v1
oid sha256:e58c005be28ac2e2b2368fa1832e7910da8bdc25fb946134813d419f10744c81
size 741
=======
﻿using MongoDB.Driver;

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
>>>>>>> 9b4ef72 (fixed github)
