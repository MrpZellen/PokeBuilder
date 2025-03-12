using MongoDB.Bson;
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
