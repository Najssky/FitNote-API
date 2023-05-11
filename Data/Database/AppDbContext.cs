using FitNote_API.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;

namespace FitNote_API.Data.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
