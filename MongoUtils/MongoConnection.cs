using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

namespace MongoUtils
{
    public class MongoConnection
    {
        static HttpClient client = new HttpClient();
        private String mongoPath = "mongodb+srv://generic:g3n3r1cpwd@cluster0-k9guk.mongodb.net/test?w=majority";
        static MongoClient dbClient = new MongoClient();

        public IMongoCollection<BsonDocument> ConnectionToMongo()
        {
            String result = "";
            //MongoClient dbClient = new MongoClient("mongodb+srv://generic:g3n3r1cpwd@cluster0-k9guk.mongodb.net/" + coll);
             dbClient = new MongoClient(mongoPath);

             var db = dbClient.GetDatabase("test");
            Console.WriteLine(db.GetCollection<BsonDocument>("users"));
            var collection = db.GetCollection<BsonDocument>("users");
            return collection;
        }
        public String getRandomKeyAsync(String coll, String field)
        {
            String result = "";
            var collection = ConnectionToMongo();
            var sample = new BsonDocument
                {
                    {
                        "$sample",
                        new BsonDocument
                            {
                                {"size", 1}
                            }
                    }
                };
            var pipeline = new[] { sample };
            var sampleList = collection.Aggregate<BsonDocument>(pipeline);
            foreach (var doc in sampleList.ToList())
            {
 
                result = doc.GetValue(field).ToString();
                
            }
            return result;
        }
    }

       // var documents = await SpeCollection.Find(Builders<Project>.Filter.Empty).ToListAsync();

    
}