using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace orderoni.Models
{
    public class Storefront
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("businessName")]
        public string BusinessName { get; set; }

        [BsonElement("ownerType")]
        public string OwnerType { get; set; }

        [BsonElement("ownerFIrstName")]
        public string OwnerFirstName { get; set; }

        [BsonElement("ownerLastName")]
        public string OwnerLastName { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("location")]
        public string Location { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("dateEntered")]
        public string DateEntered { get; set; }

        [BsonElement("rating")]
        public string Rating { get; set; }

        [BsonElement("images")]
        public BsonArray Images { get; set; }

        [BsonElement("menus")]
        public BsonArray Menus { get; set; }

    }
}
