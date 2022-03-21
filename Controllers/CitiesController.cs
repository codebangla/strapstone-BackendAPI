using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;
using API.Interfaces;
using AutoMapper;
using API.Dtos;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CitiesController(IUnitOfWork uow, IMapper mapper)
        {
            this._uow = uow;
            this._mapper = mapper;
        }

        // GET: api/Cities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> GetCities()

        {
            var cities = await _uow.CityRepository.GetCitiesAsync();
            var citiesDto = _mapper.Map<IEnumerable<CityDto>>(cities);
            return Ok(citiesDto);
        }

        // GET: api/Cities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GetCity(int id)
        {

            var city = await _uow.CityRepository.GetCity(id);
            return city;
        }

        //// PUT: api/Cities/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCity(int id, City city)
        //{
        //    if (id != city.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(city).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CityExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Cities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<City>> PostCity(City city)
        {
            _uow.CityRepository.PostCity(city);

            await _uow.SaveAsync();

            return  CreatedAtAction("GetCity", new { id = city.Id }, city);
        }

        // DELETE: api/Cities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {

            _uow.CityRepository.DeleteCity(id);
            await _uow.SaveAsync();
            return Ok(id);
        }

    }
}
