using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DriversAPI.Models
{
    public class Drivers
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("Name")]
        public string Name { get; set; }
        public int Number { get; set; }
        public string Team { get; set; } = string.Empty;

    }
}
