using demo.proyect.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace demo.proyect_persistance.Configuration;

public class IndicatorPeriodStateEntityConfiguration : IEntityTypeConfiguration<IndicatorPeriodStateEntity>
{
    public void Configure(EntityTypeBuilder<IndicatorPeriodStateEntity> builder)
    {
        builder.ToTable("indicador_periodo_estado", "dbo");
        builder.HasKey(e => new { e.IndicatorId, e.PeriodId, e.StateId });
        builder.Property(e => e.Comment).IsRequired().HasMaxLength(250);
        builder.Property(e => e.CreatedBy).IsRequired(true).HasMaxLength(100);
        builder.Property(e => e.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("GETDATE()");
        builder.Property(e => e.UpdatedBy).IsRequired(false).HasMaxLength(100);
        builder.Property(e => e.UpdatedAt).ValueGeneratedOnUpdate().HasDefaultValueSql("GETDATE()");
        builder.Property(e => e.IsActive).HasDefaultValue(true);
        builder.Property(e => e.IsDeleted).HasDefaultValue(false);
        builder.Property(e => e.RowGuid).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
        builder.HasIndex(e => e.RowGuid).IsUnique();
        builder.HasOne(e => e.IndicatorEntity).WithMany().HasForeignKey(e => e.IndicatorId);
        builder.HasOne(e => e.PeriodEntity).WithMany().HasForeignKey(e => e.PeriodId);
        builder.HasOne(e => e.StateEntity).WithMany().HasForeignKey(e => e.StateId);
    }
}