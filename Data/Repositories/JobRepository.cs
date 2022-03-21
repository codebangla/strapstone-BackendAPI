using API.Interfaces;
using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Repositories
{
    public class JobRepository : IJobRepository
    {

        private readonly DataContext _context;
        public JobRepository(DataContext context)
        {
            this._context = context;

        }

        public void DeleteJob(int JobId)
        {
            var job = _context.Jobs.Find(JobId);

            _context.Jobs.Remove(job);
        }

        public async Task<Job> GetJobDetailAsync(int id)
        {
            return await _context.Jobs.FindAsync(id);
        }

        public async Task<IEnumerable<Job>> GetJobsAsync()
        {
            return await _context.Jobs.ToListAsync();
        }

        public void PostJob(Job job)
        {
            _context.Jobs.Add(job);
        }



    }
}
