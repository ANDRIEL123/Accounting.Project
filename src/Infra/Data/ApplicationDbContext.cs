using Accounting.Project.src.Infra.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Accounting.Project.src.Infra.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            IConfiguration configuration
        ) : base(options)
        {
            _configuration = configuration;

            // Cria schema e tables caso não tenha
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");

                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(connectionString, options =>
                    {
                        options.EnableRetryOnFailure();
                    });
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            InjectMappings.Add(modelBuilder);
        }
    }
}