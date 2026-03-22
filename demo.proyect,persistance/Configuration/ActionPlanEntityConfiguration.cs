using demo.proyect.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace demo.proyect_persistance.Configuration;

public class ActionPlanEntityConfiguration : IEntityTypeConfiguration<ActionPlanEntity>
{
    public void Configure(EntityTypeBuilder<ActionPlanEntity> builder)
    {
        builder.ToTable("plan_accion", "dbo");
        builder.HasKey(e => e.ActionPlanId);
        builder.Property(e => e.ActionPlanId).ValueGeneratedOnAdd();
        builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
        builder.HasIndex(e => e.Name).IsUnique();
        builder.Property(e => e.Description).HasMaxLength(500);
        builder.Property(e => e.Budget);
        builder.Property(e => e.IsExecutable).HasDefaultValue(false);
        builder.Property(e => e.Converted).HasDefaultValue(false);
        builder.HasOne(e => e.AreaEntity).WithMany().HasForeignKey(e => e.AreaId);
        builder.Property(e => e.Order).HasDefaultValue(0);
        builder.HasOne(e => e.Initiative).WithMany().HasForeignKey(e => e.InitiativeId).OnDelete(DeleteBehavior.Cascade);
        builder.Property(e => e.CreatedBy).IsRequired(true).HasMaxLength(100);
        builder.Property(e => e.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("GETDATE()");
        builder.Property(e => e.UpdatedBy).IsRequired(false).HasMaxLength(100);
        builder.Property(e => e.UpdatedAt).ValueGeneratedOnUpdate().HasDefaultValueSql("GETDATE()");
        builder.Property(e => e.IsActive).HasDefaultValue(true);
        builder.Property(e => e.IsDeleted).HasDefaultValue(false);
        builder.Property(e => e.RowGuid).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
        builder.HasIndex(e => e.RowGuid).IsUnique();
    }
}