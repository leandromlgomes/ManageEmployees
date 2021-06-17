using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class DepartmentMap : IEntityTypeConfiguration<DepartmentEntity>
    {
        public void Configure(EntityTypeBuilder<DepartmentEntity> builder)
        {
            builder.ToTable("Department");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.DepartmentName).IsRequired()
            .HasMaxLength(50);

        }
    }
}
