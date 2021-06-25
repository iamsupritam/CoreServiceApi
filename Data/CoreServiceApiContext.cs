using CoreServiceApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreServiceApi.data
{
    public class CoreServiceApiContext : DbContext
    {
        public CoreServiceApiContext(DbContextOptions<CoreServiceApiContext> opt) : base(opt)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}