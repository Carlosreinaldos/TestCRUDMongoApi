using CRUD_MongoDB.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_MongoDB.DbModels
{
    public class ObjectContext
    {
        public IConfigurationRoot Configuration { get; }
        private IMongoDatabase _database = null;

        public ObjectContext(IOptions<Settings> settings)
        {
            Configuration = settings.Value.IConfigurationRoot;
            settings.Value.ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
            settings.Value.ConnectionString = Configuration.GetSection("MongoConnection:Database").Value;

            var client = new MongoClient(settings.Value.ConnectionString);
            if(client != null)
            {
                _database = client.GetDatabase(settings.Value.ConnectionString);
            }
        }

        public IMongoCollection<Student> Students
        {
            get
            {
                return _database.GetCollection<Student>("Student");
            }
        }
    }
}
