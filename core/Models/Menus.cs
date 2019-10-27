using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace orderoni.Models
{
    public class Menus
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        
        [BsonElement("kitchen")]
        public string Kitchen { get; set; }

        [BsonElement("smallImage")]
        public string SmallImage { get; set; }

        [BsonElement("items")]
        public string Items { get; set; }

        [BsonElement("location")]
        public string Location { get; set; }

        [BsonElement("dateEntered")]
        public string DateEntered { get; set; }

    }
}
