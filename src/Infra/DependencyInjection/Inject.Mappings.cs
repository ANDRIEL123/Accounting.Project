using Accounting.Project.src.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Accounting.Project.src.Infra.DependencyInjection
{
    public class InjectMappings
    {
        public static void Add(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AssetsMapping());
            modelBuilder.ApplyConfiguration(new PeopleMapping());
            modelBuilder.ApplyConfiguration(new AccountsMapping());
            modelBuilder.ApplyConfiguration(new ReleasesMapping());
            modelBuilder.ApplyConfiguration(new NotesMapping());
        }
    }
}