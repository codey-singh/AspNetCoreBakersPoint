using BakersPoint.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace BakersPoint.Infrastructure
{
    public interface IApplicationContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<Invoice> Invoices { get; set; }

        Task SaveChangesAsync();
    }

    public class ApplicationContext : DbContext, IApplicationContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        public async Task SaveChangesAsync()
        {
            await base.SaveChangesAsync();
        }
    }
    
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationContext> 
    { 
        public ApplicationContext CreateDbContext(string[] args) 
        { 
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@Directory.GetCurrentDirectory() + "/../BakersPoint.Api/appsettings.json")
                .Build(); 
            
            var builder = new DbContextOptionsBuilder<ApplicationContext>(); 
            var connectionString = configuration.GetConnectionString("DefaultConnection"); 
            builder.UseSqlServer(connectionString); 
            return new ApplicationContext(builder.Options); 
        } 
    }
}