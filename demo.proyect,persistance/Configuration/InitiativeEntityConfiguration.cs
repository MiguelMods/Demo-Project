using demo.proyect.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace demo.proyect_persistance.Configuration;

public class InitiativeEntityConfiguration : IEntityTypeConfiguration<InitiativeEntity>
{
    public void Configure(EntityTypeBuilder<InitiativeEntity> builder)
    {
        builder.ToTable("iniciativa", "dbo");
        builder.HasKey(e => e.InitiativeId);
        builder.Property(e => e.InitiativeId).ValueGeneratedOnAdd();
        builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
        builder.HasIndex(e => e.Name).IsUnique();
        builder.Property(e => e.Description).HasMaxLength(500);
        builder.HasOne(e => e.ActionPlanEntity).WithMany().HasForeignKey(e => e.ActionPlanOriginId).OnDelete(DeleteBehavior.Cascade);
        builder.Property(e => e.IsReal).HasDefaultValue(false);
        builder.Property(e => e.IsExecutable).HasDefaultValue(false);
        builder.HasOne(e => e.Goal).WithMany().HasForeignKey(e => e.GoalId).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(e => e.Area).WithMany().HasForeignKey(e => e.AreaId).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(e => e.ActionPlanEntities).WithOne(e => e.Initiative).HasForeignKey(e => e.ActionPlanId).OnDelete(DeleteBehavior.NoAction);
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