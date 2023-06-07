using LivrariaApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LivrariaApp.Infrastructure.Data
{
    public class MySqlDbContext : DbContext
    {
        public MySqlDbContext(DbContextOptions<MySqlDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
    }
}
