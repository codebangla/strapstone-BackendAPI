
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IUnitOfWork
    {
        ICityRepository CityRepository { get;  }
        IJobRepository JobRepository { get; }
        IUserRepository UserRepository { get; }
        Task<bool> SaveAsync();

    }

   
}
