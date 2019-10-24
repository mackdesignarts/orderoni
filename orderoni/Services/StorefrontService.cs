using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using orderoni.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace orderoni.Services
{
    public class StorefrontService
    {
        private readonly IMongoCollection<Storefront> _storefront;

        public StorefrontService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("orderoniDB"));
            var database = client.GetDatabase("orderoniDB");

            _storefront = database.GetCollection<Storefront>("storefront");
        }

        public List<Storefront> Get()
        {
            return _storefront.Find(Storefront => true).ToList();
        }

        public Storefront Get(string id)
        {
            return _storefront.Find<Storefront>(Storefront => Storefront.Id == id).FirstOrDefault();
        }

        public Storefront Create(Storefront Storefront)
        {
            _storefront.InsertOne(Storefront);
            return Storefront;
        }

        public void Update(string id, Storefront portIn)
        {
            _storefront.ReplaceOne(Storefront => Storefront.Id == id, portIn);
        }

        public void Remove(Storefront portIn)
        {
            _storefront.DeleteOne(Storefront => Storefront.Id == portIn.Id);
        }

        public void Remove(string id)
        {
            _storefront.DeleteOne(Storefront => Storefront.Id == id);
        }

    }
}
