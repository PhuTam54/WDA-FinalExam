using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinalExam.Models;
using Microsoft.CodeAnalysis;

namespace FinalExam.Data
{
    public class FinalExamContext : DbContext
    {
        public FinalExamContext (DbContextOptions<FinalExamContext> options)
            : base(options)
        {
        }
        public DbSet<Department> Department { get; set; } = default!;
        public DbSet<User> User { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Department>().ToTable("Department");
        }
    }
}
