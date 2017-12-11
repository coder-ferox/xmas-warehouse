using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace GestioneLetterine.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }

        [BsonElement("screenname")]
        public string ScreenName { get; }

        [BsonElement("email")]
        public string email { get; }

        [BsonElement("isAdmin")]
        public bool IsAdmin { get; }

        [BsonElement("password")]
        public string Password { get; }

        [BsonElement("password_clear_text")]
        public string Password_Clear_Text { get; }


    }
}