using ContentNegotiationInCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContentNegotiationInCore.DataContext
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Student> Students { get; set; }
    }
}
