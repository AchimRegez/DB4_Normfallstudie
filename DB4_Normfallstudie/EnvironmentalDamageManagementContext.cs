using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace DB4_Normfallstudie
{
    internal class EnvironmentalDamageManagementContext : DbContext
    {
        public DbSet<Involved>? Involved { get; set; }
        public DbSet<Owner>? Owners { get; set; }
        public DbSet<Employee>? Employees { get; set; }
        public DbSet<LandRegistry>? LandRegistryOffices { get; set; }
        public DbSet<Object>? Objects { get; set; }
        public DbSet<Hazard>? Hazards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["NormfallstudieDB4"].ConnectionString);
        }
    }

}
