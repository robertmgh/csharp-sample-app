using csharp_sample_app.Core.Entities;
using csharp_sample_app.Core.Repositories;
using csharp_sample_app.Infrastructure.Mongo.Documents;
using csharp_sample_app.Infrastructure.Mongo.Settings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace csharp_sample_app.Infrastructure.Mongo.Repositories
{
    internal class UsersMongoRepository : IUsersRepository
    {
        private readonly IMongoCollection<UserDocument> _users;

        public UsersMongoRepository(IUsersDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<UserDocument>(settings.UsersCollectionName);
        }

        public async Task<User> GetAsync(Guid id)
        {
            var user = await _users.Find(user => user.Id == id).FirstOrDefaultAsync();

            if (user == null)
            {
                return null;
            }
            else
            {
                return user.AsEntity();
            }
        }

        public async Task<IEnumerable<User>> GetListAsync()
        {
            var users = await _users.Find(user => true).ToListAsync();

            return users.Select(userDoc => userDoc.AsEntity());
        }

        public Task AddAsync(User user)
            => _users.InsertOneAsync(user.AsDocument());

        public Task UpdateAsync(User newUser)
            => _users.ReplaceOneAsync(user => user.Id == newUser.Id, newUser.AsDocument());

        public Task DeleteAsync(Guid id)
            => _users.DeleteOneAsync(user => user.Id == id);
    }
}
