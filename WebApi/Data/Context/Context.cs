using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Strength> Strengths { get; set; }
        public DbSet<TobaccoProduct> Products { get; set; }
        public DbSet<AdminLogin> AdminLogins { get; set; }
        public DbSet<StoreOrder> StoreOrders { get; set; }
    }
}