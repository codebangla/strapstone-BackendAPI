﻿using API.Data.Repositories;
using API.Interfaces;
using System.Threading.Tasks;

namespace API.Data
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly DataContext _context;
        public UnitOfWork(DataContext context)
        {
            this._context = context;
        }

        public ICityRepository CityRepository =>
            new CityRepository(_context);

        public IJobRepository JobRepository =>
           new JobRepository(_context);

        public IUserRepository UserRepository =>
            new UserRepository(_context);

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
