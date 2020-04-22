using System;
using Microsoft.EntityFrameworkCore;

namespace Celo.Data.InMemory
{
    public class UserDataContext : DbContext
    {
        public DbSet<User> User { get; set; }

        public UserDataContext()
        {
        }

        public UserDataContext(DbContextOptions<UserDataContext> options) : base(options)
        {

        }
    }
}
