using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Accounting.Project.src.Entities;

namespace Accounting.Project.src.Mappings
{
    public class ReleasesMapping : IEntityTypeConfiguration<Releases>
    {
        public void Configure(EntityTypeBuilder<Releases> builder)
        {
            builder.ToTable("releases");

            builder
               .HasOne(p => p.Account)
               .WithMany(c => c.Releases)
               .HasForeignKey(p => p.AccountId);
        }
    }
}