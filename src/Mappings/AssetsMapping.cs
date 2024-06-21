using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Accounting.Project.src.Entities;

namespace Accounting.Project.src.Mappings
{
    public class AssetsMapping : IEntityTypeConfiguration<Assets>
    {
        public void Configure(EntityTypeBuilder<Assets> builder)
        {
            builder.ToTable("assets");

            builder
               .HasOne(p => p.Account)
               .WithMany(c => c.Assets)
               .HasForeignKey(p => p.AccountId);
        }
    }
}