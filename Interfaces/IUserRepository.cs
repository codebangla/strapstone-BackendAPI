using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Authenticate(string username, string password);
        void Register(string username, string password);

        Task<bool> UserAlreadyExists(string username);
    }
}
