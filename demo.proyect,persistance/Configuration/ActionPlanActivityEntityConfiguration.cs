using demo.proyect.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace demo.proyect_persistance.Configuration;

public class ActionPlanActivityEntityConfiguration : IEntityTypeConfiguration<ActionPlanActivityEntity>
{
    public void Configure(EntityTypeBuilder<ActionPlanActivityEntity> builder)
    {
        builder.ToTable("planes_accion_acciones", "dbo");
        builder.HasKey(e => new { e.ActionPlanId, e.ActivityId });
        builder.Property(e => e.Contribution).IsRequired();
        builder.Property(e => e.ContributionIsValid).IsRequired(false).HasDefaultValue(false);
        builder.Property(e => e.Comment).IsRequired().HasMaxLength(250);
        builder.Property(e => e.CreatedBy).IsRequired(true).HasMaxLength(100);
        builder.Property(e => e.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("GETDATE()");
        builder.Property(e => e.UpdatedBy).IsRequired(false).HasMaxLength(100);
        builder.Property(e => e.UpdatedAt).ValueGeneratedOnUpdate().HasDefaultValueSql("GETDATE()");
        builder.Property(e => e.IsActive).HasDefaultValue(true);
        builder.Property(e => e.IsDeleted).HasDefaultValue(false);
        builder.Property(e => e.RowGuid).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
        builder.HasIndex(e => e.RowGuid).IsUnique();
        builder.HasOne(e => e.Activity).WithMany().HasForeignKey(e => e.ActivityId);
        builder.HasOne(e => e.ActionPlan).WithMany().HasForeignKey(e => e.ActionPlanId);
    }
}