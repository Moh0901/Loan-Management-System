using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LoanmSystem.Model
{
    public class DBContext: DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }
        public DbSet<User> user { get; set; }

        public DbSet<Loan> loan { get; set; }
    }
}
