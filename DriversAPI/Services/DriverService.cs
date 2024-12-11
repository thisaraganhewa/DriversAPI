using DriversAPI.Models;
using MongoDB.Driver;

namespace DriversAPI.Services
{
    public class DriverService
    {

        private readonly IMongoCollection<Drivers> _driversCollection;

    }
}
