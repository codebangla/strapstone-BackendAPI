using API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IJobRepository
    {
        Task<IEnumerable<Job>> GetJobsAsync();
        void PostJob(Job job);
        void DeleteJob(int JobId);
        Task<Job> GetJobDetailAsync(int id);
    }
}
