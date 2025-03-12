<<<<<<< HEAD
version https://git-lfs.github.com/spec/v1
oid sha256:73b9c021fb93c71d375898dfec4bb1fb404c610bd0e3ea9d4a0944505fc0a511
size 271
=======
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.EntityFrameworkCore;

namespace PokeBuilderMAUI.Shared.Models
{
    [Collection("UserInformationStorage")]
    public class User
    {
        //BSonId is used to define the Id variable in the MongoDB collection
        //BsonRepresentation is used to define the type of the Id variable in the MongoDB collection
        //BsonElement is used to define the variable name in the MongoDB collection
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]        
        public string? _id { get; set; }

        //The RegexExpression tag is used to define what is permitted in regex.
        //User: 8-20 characters, no special characters except ! and $
        [RegularExpression(@"^[a-zA-Z0-9!$]{8,20}$", ErrorMessage = "Characters are not allowed.")]
        [Required(ErrorMessage = "Username is required.")]
        [BsonElement("username")]
        public string Username { get; set; }

        //Pass: 12-36 characters, at least one lowercase, one uppercase, one number, one special character
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+\-=\[\]{};':""\\|,.<>\/?]).{12,36}$", ErrorMessage = "Characters are not allowed.")]
        [Required(ErrorMessage = "Password is required.")]
        [BsonElement("password")]
        public string Password { get; set; }

        [BsonElement("teams")]
        public List<Pokemon[]> Teams { get; set; } = new List<Pokemon[]>();
    }
}
>>>>>>> 9b4ef72 (fixed github)
