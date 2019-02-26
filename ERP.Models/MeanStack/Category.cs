using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models.MeanStack
{
    [BsonIgnoreExtraElements]
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("code")]
        public string Code { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("isCommon")]
        public bool IsCommon { get; set; }
    }
}
