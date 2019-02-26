using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Models.MeanStack;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ERP.Services.MeanStack
{
    public class CategoryService
    {
        private readonly IMongoCollection<Category> _categories;

        public CategoryService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("ExpenseStoreMongoDb"));
            var database = client.GetDatabase("ng6crud");
            _categories = database.GetCollection<Category>("categories");
        }

        public List<Category> Get()
        {
            return _categories.Find(new BsonDocument()).ToList();
        }

        public Category Get(string id)
        {
            return _categories.Find<Category>(category => category.Id == id).FirstOrDefault();
        }

        public Category Create(Category category)
        {
            _categories.InsertOne(category);
            return category;
        }

        public void Update(string id, Category bookIn)
        {
            _categories.ReplaceOne(category => category.Id == id, bookIn);
        }

        public void Remove(Category bookIn)
        {
            _categories.DeleteOne(category => category.Id == bookIn.Id);
        }

        public void Remove(string id)
        {
            _categories.DeleteOne(category => category.Id == id);
        }
    }
}
