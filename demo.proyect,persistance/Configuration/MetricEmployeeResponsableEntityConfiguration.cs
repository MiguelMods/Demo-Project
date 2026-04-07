using demo.proyect.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace demo.proyect_persistance.Configuration;

public class MetricEmployeeResponsableEntityConfiguration : IEntityTypeConfiguration<MetricEmployeeResponsableEntity>
{
    public void Configure(EntityTypeBuilder<MetricEmployeeResponsableEntity> builder)
    {
        builder.ToTable("metrica_empleado_responsable", "dbo");
        builder.HasKey(e => new { e.MetricId, e.EmployeeId });
        builder.Property(e => e.CreatedBy).IsRequired(true).HasMaxLength(100);
        builder.Property(e => e.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("GETDATE()");
        builder.Property(e => e.UpdatedBy).IsRequired(false).HasMaxLength(100);
        builder.Property(e => e.UpdatedAt).ValueGeneratedOnUpdate().HasDefaultValueSql("GETDATE()");
        builder.Property(e => e.IsActive).HasDefaultValue(true);
        builder.Property(e => e.IsDeleted).HasDefaultValue(false);
        builder.Property(e => e.RowGuid).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
        builder.HasIndex(e => e.RowGuid).IsUnique();
        builder.HasOne(e => e.Metric).WithMany().HasForeignKey(e => e.MetricId);
        builder.HasOne(e => e.Employee).WithMany().HasForeignKey(e => e.EmployeeId);
        builder.Property(e => e.Comment).IsRequired().HasMaxLength(250);
    }
}