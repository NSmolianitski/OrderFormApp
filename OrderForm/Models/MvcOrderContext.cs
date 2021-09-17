using System;
using Microsoft.EntityFrameworkCore;

namespace OrderForm.Models
{
    public class MvcOrderContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        
        public MvcOrderContext(DbContextOptions<MvcOrderContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}