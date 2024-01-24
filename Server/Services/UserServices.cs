using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Server.Database;
using Server.Models;

namespace Server.Services
{
    public class UserServices
    {
        private readonly IMongoCollection<User> _userCollection;

        public UserServices(IOptions<MongoDBSettings> mongoDBSettins)
        {
            MongoClient client = new MongoClient(mongoDBSettins.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettins.Value.DatabaseName);
            _userCollection = database.GetCollection<User>(mongoDBSettins.Value.UserCollectionName);
        }

        public async Task CreateUserServices(User user)
        {
            await _userCollection.InsertOneAsync(user);
            return;
        }

        public async Task<List<User>> FindAllUsersServices()
        {
            return await _userCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task UpdateUserServices(string id, User user)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq("Id", id);
            UpdateDefinition<User> update = Builders<User>.Update
                .Set(u => u.Name, user.Name)
                .Set(u => u.Username, user.Username)
                .Set(u => u.Email, user.Email)
                .Set(u => u.Password, user.Password)
                .Set(u => u.Icon, user.Icon)
                .Set(u => u.Background, user.Background)
                .Set(u => u.About, user.About)
                .Set(u => u.BackgroundColor, user.BackgroundColor)
                .Set(u => u.Jlpt, user.Jlpt);


            await _userCollection.UpdateOneAsync(filter, update);
            return;
        }

        public async Task DeleteUserServices(string id)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq("Id", id);
            await _userCollection.DeleteOneAsync(filter);
            return;
        }

    }
}
