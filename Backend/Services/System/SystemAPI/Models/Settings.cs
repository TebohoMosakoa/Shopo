using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SystemAPI.Models
{
    public class Settings
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }

        public string Logo { get; set; }
        public string CarouselImage1 { get; set; }
        public string CarouselImage2 { get; set; }
        public string CarouselImage3 { get; set; }

        public string MidImage { get; set; }

        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}
