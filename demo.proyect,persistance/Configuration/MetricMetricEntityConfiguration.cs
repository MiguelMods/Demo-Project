using demo.proyect.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace demo.proyect_persistance.Configuration;

public class MetricMetricEntityConfiguration : IEntityTypeConfiguration<MetricMetricEntity>
{
    public void Configure(EntityTypeBuilder<MetricMetricEntity> builder)
    {
        builder.ToTable("metrica_nueva_metrica_vieja", "dbo");
        builder.HasKey(e => new { e.MetricOneId, e.MetricTwoId });
        builder.Property(e => e.CreatedBy).IsRequired(true).HasMaxLength(100);
        builder.Property(e => e.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("GETDATE()");
        builder.Property(e => e.UpdatedBy).IsRequired(false).HasMaxLength(100);
        builder.Property(e => e.UpdatedAt).ValueGeneratedOnUpdate().HasDefaultValueSql("GETDATE()");
        builder.Property(e => e.IsActive).HasDefaultValue(true);
        builder.Property(e => e.IsDeleted).HasDefaultValue(false);
        builder.Property(e => e.RowGuid).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
        builder.HasIndex(e => e.RowGuid).IsUnique();
        builder.HasOne(e => e.MetricOne).WithMany().HasForeignKey(e => e.MetricOneId);
        builder.HasOne(e => e.MetricTwo).WithMany().HasForeignKey(e => e.MetricTwoId);
        builder.Property(e => e.Comment).IsRequired().HasMaxLength(250);
    }
}