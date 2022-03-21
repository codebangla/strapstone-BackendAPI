using API.Interfaces;
using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Repositories
{
    public class CityRepository : ICityRepository
    {

        private readonly DataContext _context;
        public CityRepository(DataContext context)
        {
            this._context = context;
        }
        public async void DeleteCity(int CityId)
        {
            var city = await _context.Cities.FindAsync(CityId);

            _context.Cities.Remove(city);
        }

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await _context.Cities.ToListAsync();
        }

        public async Task<City> GetCity(int id)
        {
            return await _context.Cities.FindAsync(id);
        }

        public async void PostCity(City city)
        {
            _context.Cities.Add(city);
            await _context.SaveChangesAsync();
        }
    }
}
