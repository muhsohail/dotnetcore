using ERP.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ERP.WebApi
{
    public class DBContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        //IConfiguration _configuration;
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=ERPManager;Trusted_Connection=True;MultipleActiveResultSets=true");

            //
            //optionsBuilder.UseSqlServer(connectionString);

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
