using Biletall.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletall.DataAccess.Concrete.EntityFramework
{
    public class TodoSampleContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TodoSample;Trusted_Connection=true");
        }

        public DbSet<Todo> Todos { get; set; }
    }
}
