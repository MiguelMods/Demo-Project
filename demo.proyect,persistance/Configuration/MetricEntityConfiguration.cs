using demo.proyect.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace demo.proyect_persistance.Configuration;

public class MetricEntityConfiguration : IEntityTypeConfiguration<MetricEntity>
{
    public void Configure(EntityTypeBuilder<MetricEntity> builder)
    {
        builder.ToTable("metricas", "dbo");
        builder.HasKey(e => e.MetricId);
        builder.Property(e => e.MetricId).ValueGeneratedOnAdd();
        builder.Property(e => e.Code).IsRequired().HasMaxLength(6);
        builder.HasIndex(e => e.Code).IsUnique();
        builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
        builder.Property(e => e.UpdateFormEnum).HasConversion<string>();
        builder.Property(e => e.CalculationTypeEnum).HasConversion<string>();
        builder.Property(e => e.ValueTypeEnum).HasConversion<string>();
        builder.Property(e => e.FormulaText).IsRequired().HasMaxLength(500);
        builder.Property(e => e.FormulaPicUrl).IsRequired(false).HasMaxLength(100);
        builder.Property(e => e.FormulaPicData).IsRequired(false).IsFixedLength();
        builder.Property(e => e.Minimun).IsRequired();
        builder.Property(e => e.Maximun).IsRequired();
        builder.Property(e => e.ActualValue).IsRequired();
        builder.Property(e => e.CreatedBy).IsRequired(true).HasMaxLength(100);
        builder.Property(e => e.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("GETDATE()");
        builder.Property(e => e.UpdatedBy).IsRequired(false).HasMaxLength(100);
        builder.Property(e => e.UpdatedAt).ValueGeneratedOnUpdate().HasDefaultValueSql("GETDATE()");
        builder.Property(e => e.IsActive).HasDefaultValue(true);
        builder.Property(e => e.IsDeleted).HasDefaultValue(false);
        builder.Property(e => e.RowGuid).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
        builder.HasIndex(e => e.RowGuid).IsUnique();
        builder.HasOne(e => e.MetricType).WithMany().HasForeignKey(e => e.MetricType);
        builder.HasOne(e => e.UnitMeasurement).WithMany().HasForeignKey(e => e.UnitMeasurementId);
        builder.HasOne(e => e.Periodicity).WithMany().HasForeignKey(e => e.PeriodicityId);
    }
}