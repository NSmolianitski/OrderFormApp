using System;
using Microsoft.EntityFrameworkCore;

namespace OrderForm.Models
{
    public class MvcOrderContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        
        // public string DbPath { get; }

        public MvcOrderContext(DbContextOptions<MvcOrderContext> options) : base(options)
        {
            // DbPath = $"{Directory.GetCurrentDirectory()}{Path.PathSeparator}database.db";
            Database.EnsureCreated();
        }
        //
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseSqlite($"Data Source={DbPath}");
        // }
    }
}