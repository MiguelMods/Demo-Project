using demo.proyect.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace demo.proyect_persistance.Configuration;

public class IndicatorEntityConfiguration : IEntityTypeConfiguration<IndicatorEntity>
{
    public void Configure(EntityTypeBuilder<IndicatorEntity> builder)
    {
        builder.ToTable("indicadores", "dbo");
        builder.HasKey(e => e.IndicatorId);
        builder.Property(e => e.IndicatorId).ValueGeneratedOnAdd();
        builder.Property(e => e.Code).IsRequired().HasMaxLength(6);
        builder.HasIndex(e => e.Code).IsUnique();
        builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
        builder.HasIndex(e => e.Name).IsUnique();
        builder.Property(e => e.Description).HasMaxLength(500);
        builder.Property(e => e.CalculationType).HasConversion<string>();
        builder.Property(e => e.ValueType).HasConversion<string>();
        builder.Property(e => e.DataOriginType).HasConversion<string>();
        builder.Property(e => e.FormulaText).IsRequired().HasMaxLength(500);
        builder.Property(e => e.FormulaPicture).IsRequired(false);
        builder.Property(e => e.FormulaPictureUrl).IsRequired(false);
        builder.Property(e => e.WeightedWeight).IsRequired(false);
        builder.Property(e => e.CreatedBy).IsRequired(true).HasMaxLength(100);
        builder.Property(e => e.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("GETDATE()");
        builder.Property(e => e.UpdatedBy).IsRequired(false).HasMaxLength(100);
        builder.Property(e => e.UpdatedAt).ValueGeneratedOnUpdate().HasDefaultValueSql("GETDATE()");
        builder.Property(e => e.IsActive).HasDefaultValue(true);
        builder.Property(e => e.IsDeleted).HasDefaultValue(false);
        builder.Property(e => e.RowGuid).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
        builder.HasIndex(e => e.RowGuid).IsUnique();
        builder.HasOne(e => e.GoalEntity).WithMany().HasForeignKey(e => e.GoalId);
        builder.HasOne(e => e.UnitMeasurement).WithMany().HasForeignKey(e => e.UnitMeasurementId);
        builder.HasOne(e => e.OriginElement).WithMany().HasForeignKey(e => e.OriginElementId);
        builder.HasOne(e => e.PeriodicityCalc).WithMany().HasForeignKey(e => e.PeriodicityCalcId);
        builder.HasOne(e => e.PeriodicityPresentation).WithMany().HasForeignKey(e => e.PeriodicityPresentationId);
    }
}