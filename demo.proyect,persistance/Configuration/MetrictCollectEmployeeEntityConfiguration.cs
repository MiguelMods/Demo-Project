using demo.proyect.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace demo.proyect_persistance.Configuration;

public class MetrictCollectEmployeeEntityConfiguration : IEntityTypeConfiguration<MetrictCollectEmployeeEntity>
{
    public void Configure(EntityTypeBuilder<MetrictCollectEmployeeEntity> builder)
    {
        builder.ToTable("metrica_colectar_empleado", "dbo");
        builder.HasKey(e => new { e.MetricId, e.EmployeeId });
        builder.Property(e => e.CreatedBy).IsRequired(true).HasMaxLength(100);
        builder.Property(e => e.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("GETDATE()");
        builder.Property(e => e.UpdatedBy).IsRequired(false).HasMaxLength(100);
        builder.Property(e => e.UpdatedAt).ValueGeneratedOnUpdate().HasDefaultValueSql("GETDATE()");
        builder.Property(e => e.IsActive).HasDefaultValue(true);
        builder.Property(e => e.IsDeleted).HasDefaultValue(false);
        builder.Property(e => e.RowGuid).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
        builder.HasIndex(e => e.RowGuid).IsUnique();
        builder.HasOne(e => e.MetricEntity).WithMany().HasForeignKey(e => e.MetricId);
        builder.HasOne(e => e.EmployeeEntity).WithMany().HasForeignKey(e => e.EmployeeId);
        builder.Property(e => e.Comment).IsRequired().HasMaxLength(250);
    }
}