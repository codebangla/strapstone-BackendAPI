using API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetCitiesAsync();
        void PostCity(City city);
        void DeleteCity(int CityId);
        Task<City> GetCity(int id);
    }
}
