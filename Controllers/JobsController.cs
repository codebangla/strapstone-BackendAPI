using API.Dtos;
using API.Interfaces;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    public class JobsController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public JobsController(IUnitOfWork uow, IMapper mapper)
        {
            this._uow = uow;
            this._mapper = mapper;
        }

        // GET: api/Cities
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Job>>> GetJobs()

        {
            var jobs = await _uow.JobRepository.GetJobsAsync();
            var jobsDto = _mapper.Map<IEnumerable<JobDto>>(jobs);
            return Ok(jobsDto);
        }

        // GET: api/Cities/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Job>> GetJob(int id)
        {

            var job = await _uow.JobRepository.GetJobDetailAsync(id);
            var jobDTO = _mapper.Map<JobDto>(job);
            return Ok(jobDTO);
        }

        [HttpPost]
        public async Task<ActionResult<Job>> PostJob(JobDto jobDto)
        {

            var job = _mapper.Map<Job>(jobDto);
            job.UserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            _uow.JobRepository.PostJob(job);

            await _uow.SaveAsync();

            return StatusCode(201);
        }

        // DELETE: api/Cities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJob(int id)
        {

            _uow.JobRepository.DeleteJob(id);
            await _uow.SaveAsync();
            return Ok(id);
        }


        [HttpPatch("update/{id}")]
        public async Task<IActionResult> UpdateJob(int id, JobDto jobDto)
        {
            //if (id != jobDto.id)
            //    return BadRequest("Update not allowed");

            var jobFromDb = await _uow.JobRepository.GetJobDetailAsync(id);

            if (jobFromDb == null)
                return BadRequest("Update not allowed");

           
            _mapper.Map(jobDto, jobFromDb);

            await _uow.SaveAsync();
            return StatusCode(200);
        }
    }
}
