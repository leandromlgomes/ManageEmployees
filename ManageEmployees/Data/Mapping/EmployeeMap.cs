using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class EmployeeMap : IEntityTypeConfiguration<EmployeeEntity>
    {
        public void Configure(EntityTypeBuilder<EmployeeEntity> builder)
        {
            builder.ToTable("Employee");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Name).IsRequired()
            .HasMaxLength(50);

            builder.Property(u => u.Surname).IsRequired()
            .HasMaxLength(150);

            builder.Property(u => u.Email).IsRequired()
            .HasMaxLength(200);

            builder.Property(u => u.EmployeeNumber).IsRequired()
           .HasMaxLength(150);

            builder.HasIndex(u => u.EmployeeNumber)
               .IsUnique();

            builder.Property(u => u.Phone)
            .HasMaxLength(50);

            builder.Property(u => u.Password)
            .HasMaxLength(50);

            builder.Property(u => u.LeaderName)
           .HasMaxLength(50);

        }
    }
}
