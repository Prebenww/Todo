using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoAPI.Model
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        //[System.Text.Json.Serialization.JsonIgnore]
        public string? Id { get; set; }
        public string name { get; set; }

        public string lastName { get; set; }

        public string age { get; set; }

        public string city { get; set; }
    }
    
}
