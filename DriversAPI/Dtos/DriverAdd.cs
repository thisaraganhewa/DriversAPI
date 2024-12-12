using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DriversAPI.Dtos
{
    public class DriverAdd
    {

        [BsonElement("Name")]
        public string Name { get; set; }
        public int Number { get; set; }
        public string Team { get; set; } = string.Empty;

    }
}
