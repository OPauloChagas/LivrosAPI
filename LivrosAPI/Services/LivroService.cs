using LivrosAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace LivrosAPI.Services
{
    public class LivroService
    {
        private readonly IMongoCollection<Livro> _LivroCollection;
        public LivroService(
            IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
            _LivroCollection = mongoDatabase.GetCollection<Livro>("Livro");
        }

        public async Task<List<Livro>> GetAsync() =>
            await _LivroCollection.Find(_ => true).ToListAsync();

        public async Task<Livro?> GetAsync(string id) =>
            await _LivroCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Livro newlivro) =>
            await _LivroCollection.InsertOneAsync(newlivro);

        public async Task UpdateAsync(string id, Livro updatelivro) =>
            await _LivroCollection.ReplaceOneAsync(x => x.Id == id, updatelivro);

        public async Task RemoveAsync(string id) =>
            await _LivroCollection.DeleteOneAsync(x => x.Id == id);
    }
}
