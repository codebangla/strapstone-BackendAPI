using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace API.Data
{
    public class DataContext :DbContext
    {
        protected readonly IConfiguration Configuration;
        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            // connect to sql server with connection string from app settings
            options.UseSqlServer(Configuration.GetConnectionString("StraptoneDatabase"));

        public DbSet<User> Users { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Job> Jobs { get; set; }

       
    }
}
