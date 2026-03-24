using demo.proyect.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace demo.proyect_persistance.Configuration;

public class PeriodEntityConfiguration : IEntityTypeConfiguration<PeriodEntity>
{
    public void Configure(EntityTypeBuilder<PeriodEntity> builder)
    {
        builder.ToTable("periodo", "dbo");
        builder.HasKey(e => e.PeriodId);
        builder.Property(e => e.PeriodId).ValueGeneratedOnAdd();
        builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
        builder.HasIndex(e => e.Name).IsUnique();
        builder.Property(e => e.Description).HasMaxLength(500);
        builder.Property(e => e.CreatedBy).IsRequired(true).HasMaxLength(100);
        builder.Property(e => e.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("GETDATE()");
        builder.Property(e => e.UpdatedBy).IsRequired(false).HasMaxLength(100);
        builder.Property(e => e.UpdatedAt).ValueGeneratedOnUpdate().HasDefaultValueSql("GETDATE()");
        builder.Property(e => e.IsActive).HasDefaultValue(true);
        builder.Property(e => e.IsDeleted).HasDefaultValue(false);
        builder.Property(e => e.RowGuid).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
        builder.HasIndex(e => e.RowGuid).IsUnique();
        builder.HasData([
            new() { PeriodId = 1, Name = "Periodo de #1", Description = "Periodo de #1", CreatedBy = "Me" },
            new() { PeriodId = 2, Name = "Periodo de #2", Description = "Periodo de #2", CreatedBy = "Me" },
            new() { PeriodId = 3, Name = "Periodo de #3", Description = "Periodo de #3", CreatedBy = "Me" },
            new() { PeriodId = 4, Name = "Periodo de #4", Description = "Periodo de #4", CreatedBy = "Me" },
            ]);
    }
};