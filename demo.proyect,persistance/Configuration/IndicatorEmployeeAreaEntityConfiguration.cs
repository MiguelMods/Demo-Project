using demo.proyect.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace demo.proyect_persistance.Configuration;

public class IndicatorEmployeeAreaEntityConfiguration : IEntityTypeConfiguration<IndicatorEmployeeAreaEntity>
{
    public void Configure(EntityTypeBuilder<IndicatorEmployeeAreaEntity> builder)
    {
        builder.ToTable("indicador_empleado_area", "dbo");
        builder.HasKey(e => new { e.IndicatorId, e.EmployeeId, e.AreaId });
        builder.Property(e => e.CreatedBy).IsRequired(true).HasMaxLength(100);
        builder.Property(e => e.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("GETDATE()");
        builder.Property(e => e.UpdatedBy).IsRequired(false).HasMaxLength(100);
        builder.Property(e => e.UpdatedAt).ValueGeneratedOnUpdate().HasDefaultValueSql("GETDATE()");
        builder.Property(e => e.IsActive).HasDefaultValue(true);
        builder.Property(e => e.IsDeleted).HasDefaultValue(false);
        builder.Property(e => e.RowGuid).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
        builder.HasIndex(e => e.RowGuid).IsUnique();
        builder.HasOne(e => e.IndicatorEntity).WithMany().HasForeignKey(e => e.IndicatorId);
        builder.HasOne(e => e.EmployeeEntity).WithMany().HasForeignKey(e => e.EmployeeId);
        builder.HasOne(e => e.AreaEntity).WithMany().HasForeignKey(e => e.AreaId);
        builder.Property(e => e.Comment).IsRequired().HasMaxLength(250);
    }
}
