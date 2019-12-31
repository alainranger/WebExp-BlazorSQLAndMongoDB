using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSQLAndMongoDB.Data
{
    public interface ICityService
    {
        Task<List<City>> GetCities();
        Task<bool> CreateCity(City city);
        Task<bool> EditCity(string id, City city);
        Task<City> SingleCity(string id);
        Task<bool> DeleteCity(string id);
    }
}
