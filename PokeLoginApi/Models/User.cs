<<<<<<< HEAD
version https://git-lfs.github.com/spec/v1
oid sha256:424ec1c65078fd0003e0e5e22505953812aa34851d4335902891a7280b2dd243
size 777
=======
﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PokeLoginApi.Models
{
    public class User
    {
        [BsonId]
        [BsonElement("id"), BsonRepresentation(BsonType.ObjectId)]
        public int UserId { get; set; }
        [BsonElement("name"), BsonRepresentation(BsonType.String)]
        public string? Name { get; set; }
        [BsonElement("email"), BsonRepresentation(BsonType.String)]
        public string? Email { get; set; }
        [BsonElement("password"), BsonRepresentation(BsonType.String)]
        public string? Password { get; set; }

    }
}
>>>>>>> 9b4ef72 (fixed github)
