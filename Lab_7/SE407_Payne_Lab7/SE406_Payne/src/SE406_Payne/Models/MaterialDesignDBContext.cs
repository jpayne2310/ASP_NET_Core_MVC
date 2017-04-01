using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace SE406_Payne.Models
{
    public class MaterialDesignDBContext : DbContext
    {
        public IConfigurationRoot Configuration { get; set; }
        public DbSet<MaterialDesign> MaterialDesigns { get; set; }
        public MaterialDesignDBContext()
        {
            var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                Configuration.GetConnectionString("MSSQLDB"));
            base.OnConfiguring(optionsBuilder);
        }
    }

}
