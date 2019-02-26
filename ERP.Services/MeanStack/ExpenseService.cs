using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Models.MeanStack;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ERP.Services.MeanStack
{
    public class ExpenseService
    {
        private readonly IMongoCollection<Expense> _expenses;

        public ExpenseService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("ExpenseStoreMongoDb"));
            var database = client.GetDatabase("ng6crud");
            _expenses = database.GetCollection<Expense>("expenses");
        }

        public List<Expense> Get()
        {
            return _expenses.Find(_ => true).ToList();
        }

        public Expense Get(string id)
        {
            return _expenses.Find<Expense>(expense => expense.Id == id).FirstOrDefault();
        }

        public Expense Create(Expense expense)
        {
            _expenses.InsertOne(expense);
            return expense;
        }

        public void Update(string id, Expense bookIn)
        {
            _expenses.ReplaceOne(expense => expense.Id == id, bookIn);
        }

        public void Remove(Expense bookIn)
        {
            _expenses.DeleteOne(expense => expense.Id == bookIn.Id);
        }

        public void Remove(string id)
        {
            _expenses.DeleteOne(expense => expense.Id == id);
        }
    }
}
