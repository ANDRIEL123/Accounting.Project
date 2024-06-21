using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Accounting.Project.src.Entities;

namespace Accounting.Project.src.Mappings
{
    public class AccountsMapping : IEntityTypeConfiguration<Accounts>
    {
        public void Configure(EntityTypeBuilder<Accounts> builder)
        {
            builder.ToTable("accounts");

            builder
               .HasOne(p => p.MatchAccount)
               .WithMany(c => c.MatchAccounts)
               .HasForeignKey(p => p.MatchAccountId);
        }
    }
}