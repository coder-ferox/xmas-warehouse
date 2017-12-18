using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GestioneLetterine.Classes
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("screenname")]
        public string Username { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("isAdmin")]
        public bool IsAdmin { get; set; }

        [BsonElement("password")]
        public string PasswordCrypted { get; set; }

        [BsonElement("password_clear_text")]
        public string Password { get; set; }

        public string GetSHA512(string text)
        {
            byte[] HashData, MessageBytes = Encoding.UTF8.GetBytes(text);
            SHA512Managed hash = new SHA512Managed();
            string hex = "";

            HashData = hash.ComputeHash(MessageBytes);
            foreach (byte b in HashData)
            {
                hex += String.Format("{0:x2}", b);
            }
            return hex;
        }
    }
}
