using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Accounting.Project.src.Entities;

namespace Accounting.Project.src.Mappings
{
    public class PeopleMapping : IEntityTypeConfiguration<People>
    {
        public void Configure(EntityTypeBuilder<People> builder)
        {
            builder.ToTable("people");
        }
    }
}