using demo.proyect.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace demo.proyect_persistance.Configuration;

public class ActionPlanMetricEntityConfiguration : IEntityTypeConfiguration<ActionPlanMetricEntity> 
{
    public void Configure(EntityTypeBuilder<ActionPlanMetricEntity> builder) 
    {
        builder.ToTable("Planes_de_accion_metrica", "dbo");
        builder.HasKey(e => new { e.ActionPlanId, e.MetricId });
        builder.Property(e => e.Comment).IsRequired().HasMaxLength(250);
        builder.Property(e => e.CreatedBy).IsRequired(true).HasMaxLength(100);
        builder.Property(e => e.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("GETDATE()");
        builder.Property(e => e.UpdatedBy).IsRequired(false).HasMaxLength(100);
        builder.Property(e => e.UpdatedAt).ValueGeneratedOnUpdate().HasDefaultValueSql("GETDATE()");
        builder.Property(e => e.IsActive).HasDefaultValue(true);
        builder.Property(e => e.IsDeleted).HasDefaultValue(false);
        builder.Property(e => e.RowGuid).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
        builder.HasIndex(e => e.RowGuid).IsUnique();
        builder.HasOne(e => e.ActionPlan).WithMany().HasForeignKey(e => e.ActionPlanId);
        builder.HasOne(e => e.Metric).WithMany().HasForeignKey(e => e.MetricId);
    }
}