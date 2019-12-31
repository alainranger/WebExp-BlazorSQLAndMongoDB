using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSQLAndMongoDB.Data
{
    public class CityService : ICityService
    {
        private readonly IMongoCollection<City> _cities;

        public CityService(IMongoDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _cities = database.GetCollection<City>(settings.CollectionName);
        }

        public async Task<bool> CreateCity(City city)
        {
            try
            {
                await _cities.InsertOneAsync(city);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteCity(string id)
        {
            try
            {
                await _cities.DeleteOneAsync(book => book.Id == id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> EditCity(string id, City city)
        {
            try
            {
                await _cities.ReplaceOneAsync(book => book.Id == id, city);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<City>> GetCities()
        {
            try
            {
                return await _cities.Find(city => true).ToListAsync();
            }
            catch
            {
                return null;
            }
        }

        public async Task<City> SingleCity(string id)
        {
            try
            {
                return await _cities.Find<City>(city => city.Id == id).FirstOrDefaultAsync();
            }
            catch
            {
                return null;
            }
        }
    }
}
