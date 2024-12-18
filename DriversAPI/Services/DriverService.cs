﻿using DriversAPI.Configurations;
using DriversAPI.Dtos;
using DriversAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DriversAPI.Services
{
    public class DriverService
    {

        private readonly IMongoCollection<Drivers> _driversCollection;

        public DriverService(IOptions<DatabaseSettings> databaseSettings )
        {

            var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
            var mongoDb = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
            _driversCollection = mongoDb.GetCollection<Drivers>(databaseSettings.Value.CollectionName);

            
        }

        public async Task<List<Drivers>> GetAllAsync()
        {

            return await _driversCollection.Find(_ => true).ToListAsync();

        }

        public async Task<Drivers> GetDriverByName(string name)
        {

            return await _driversCollection.Find(driver => driver.Name == name).FirstOrDefaultAsync();


        }

        public async Task<Drivers> GetDriverById(string id)
        {

            return await _driversCollection.Find(driver => driver.Id == id).FirstOrDefaultAsync();

        }

        public async Task<Drivers> AddNewDriver(DriverAdd driverDto)
        {

            var driver = new Drivers()
            {

                Name = driverDto.Name,
                Team = driverDto.Team,
                Number = driverDto.Number,

            };


            await _driversCollection.InsertOneAsync(driver);

            return driver;

            //var d = await _driversCollection.Find(driver => driver.Id == driver.Id).FirstOrDefaultAsync();

            //return d;

        }

        public async Task UpdateDriver(string id, UpdateDriverDto updateDriverDto)
        {

            var driver = new Drivers()
            {

                Id = updateDriverDto.Id,
                Name = updateDriverDto.Name,
                Number = updateDriverDto.Number,
                Team = updateDriverDto.Team,

            };

            await _driversCollection.ReplaceOneAsync(d => d.Id == id, driver);

        }

        public async Task DeleteOneDriver(string id)
        {

            await _driversCollection.DeleteOneAsync(d => d.Id == id);

        }



    }

    
}
