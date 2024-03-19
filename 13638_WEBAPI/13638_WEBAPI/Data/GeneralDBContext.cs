using _13638_WEBAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace _13638_WEBAPI.Data
{
    public class GeneralDBContext : DbContext
    {
        public GeneralDBContext(DbContextOptions<GeneralDBContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
    }
}
