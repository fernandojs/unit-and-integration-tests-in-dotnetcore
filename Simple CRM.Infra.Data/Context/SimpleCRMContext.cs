using Microsoft.EntityFrameworkCore;
using Simple_CRM.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;
using Simple_CRM.Infra.Data.Configuration;

namespace Simple_CRM.Infra.Data.Context
{
    public class SimpleCRMDbContext : DbContext, IApplicationDbContext
    {
        public SimpleCRMDbContext(DbContextOptions<SimpleCRMDbContext> options)
            : base(options)
        {
        }

        public SimpleCRMDbContext()
        {

        }

        public DbSet<Business> Business { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Sales> Sales { get; set; }        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {       
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()          
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // define the database to use
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));

        }
    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            modelBuilder.ApplyConfiguration(new BusinessConfig());
            modelBuilder.ApplyConfiguration(new CustomerConfig());
            modelBuilder.ApplyConfiguration(new SalesConfig());
          
        }
    }
}
