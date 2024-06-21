using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Accounting.Project.src.Entities;

namespace Accounting.Project.src.Mappings
{
    public class NotesMapping : IEntityTypeConfiguration<Notes>
    {
        public void Configure(EntityTypeBuilder<Notes> builder)
        {
            builder.ToTable("notes");

            builder
               .HasOne(p => p.Asset)
               .WithMany(c => c.Notes)
               .HasForeignKey(p => p.AssetId);

            builder
               .HasOne(p => p.Person)
               .WithMany(c => c.Notes)
               .HasForeignKey(p => p.PersonId);
        }
    }
}