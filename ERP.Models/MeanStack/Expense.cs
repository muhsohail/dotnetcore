using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models.MeanStack
{
    [BsonIgnoreExtraElements]
    public class Expense
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("amount")]
        public string Amount { get; set; }

        [BsonElement("dateSpent")]
        [BsonDateTimeOptions]
        public DateTime? DateSpent { get; set; }

        [BsonElement("purpose")]
        public string Purpose { get; set; }

        [BsonElement("category")] 
        public string Category { get; set; }

        [BsonElement("createdby")]
        public string Createdby { get; set; }

        [BsonElement("lastupdateddate")]
        [BsonDateTimeOptions]
        public DateTime? Lastupdateddate { get; set; }

        [BsonElement("status")]
        public string Status { get; set; }

    }
}
