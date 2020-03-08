using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoUtils
{
    public class User
    {
        public ObjectId ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }

        public User(string firstName, string lastName, string phone)
        {
            firstName = this.FirstName;
            lastName = this.LastName;
            phone = this.Phone;
        }

    }
}
