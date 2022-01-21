using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoAPI.Model;
using ToDoAPI.ViewModwl;

namespace ToDoAPI.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _user;
        public UserService(IToDoDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _user = database.GetCollection<User>(settings.UserCollectionName);

        }
        public async Task<List<User>> GetAllAsync()
        {
            List<User> users;
            users =await _user.Find(s => true).ToListAsync();
            return users;
        }

        public async Task<User> GetByIdAsync(string id)
        {
            return await _user.Find<User>(c => c.Id == id).FirstOrDefaultAsync();
        }


        public async Task<User> CreateAsync(User user)
        {
            await _user.InsertOneAsync(user);
            return user;
        }

    }
}
