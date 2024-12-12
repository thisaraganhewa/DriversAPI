using DriversAPI.Configurations;
using DriversAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DriversAPI.Services
{
    public class DriverService
    {

        private readonly IMongoCollection<Drivers> _driversCollection;

        public DriverService(/*IMongoClient _mongoClient,*/ IOptions<DatabaseSettings> databaseSettings )
        {

            var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
            //var mongoDb = new MongoClient(databaseSettings.Value.DatabaseName);
            var mongoDb = mongoClient.GetDatabase(databaseSettings.Value.CollectionName);
            //var db = _mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
            _driversCollection = mongoDb.GetCollection<Drivers>(databaseSettings.Value.CollectionName);

            
        }

        public async Task<List<Drivers>> GetAllAsync()
        {

            return await _driversCollection.Find(_ => true).ToListAsync();

        }



    }

    
}
