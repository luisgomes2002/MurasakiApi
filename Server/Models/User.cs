using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Server.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; } = null!;

        [BsonElement("username")]
        public string Username { get; set; } = null!;

        [BsonElement("email")]
        public string Email { get; set; } = null!;

        [BsonElement("password")]
        public string Password { get; set; } = null!;

        [BsonElement("icon")]
        public string Icon { get; set; } = null!;

        [BsonElement("background")]
        public string Background { get; set; } = null!;

        [BsonElement("ismod")]
        public bool IsMod { get; set; } = false;

        [BsonElement("points")]
        public int Points { get; set; } = 0;

        [BsonElement("followers")]
        [JsonPropertyName("followers")]
        public List<string> Followers { get; set; } = null!;

        [BsonElement("following")]
        [JsonPropertyName("following")]
        public List<string> Following { get; set; } = null!;

        [BsonElement("about")]
        public string About { get; set; } = null!;

        [BsonElement("backgroundColor")]
        public string BackgroundColor { get; set; } = "#121214";

        [BsonElement("jlpt")]
        public string Jlpt { get; set; } = null!;

        [BsonElement("createdate")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime CreatedAt { get; set; }
    }
}
