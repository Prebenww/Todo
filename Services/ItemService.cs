using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoAPI.Model;

namespace ToDoAPI.Services
{
    public class ItemService
    {
        private readonly IMongoCollection<Item> _item;
        public ItemService(IToDoDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _item = database.GetCollection<Item>(settings.ItemCollectionName);

        }


        public async Task<Item> CreateAsync(Item item)
        {
            await _item.InsertOneAsync(item);
            return item;
        }

        public async Task<List<Item>> GetAllAsync()
        {
            List<Item> items;
            items = await _item.Find(s => true).ToListAsync();
            return items;
        }
        public async Task<List<Item>> GetByUser(string userid)
        {
            List<Item> items;
            items = await _item.Find(s=>s.UserId==userid).ToListAsync();
            return items;
        }

        public async Task<List<Item>> GetByCategory(string category)
        {
            List<Item> items;
            items = await _item.Find(s => s.category == category).ToListAsync();
            return items;
        }
    }
}
