using demo.proyect.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace demo.proyect_persistance.Configuration;

public class GoalEntityConfiguration : IEntityTypeConfiguration<GoalEntity>
{
    public void Configure(EntityTypeBuilder<GoalEntity> builder)
    {
        builder.ToTable("objetivos", "dbo");
        builder.HasKey(e => e.GoalId);
        builder.Property(e => e.GoalId).ValueGeneratedOnAdd();
        builder.Property(e => e.Code).IsRequired().HasMaxLength(25);
        builder.HasIndex(e => e.Code).IsUnique();
        builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
        builder.Property(e => e.Description).HasMaxLength(500);
        builder.Property(e => e.Formula).HasMaxLength(50);
        builder.Property(e => e.IsReal).HasDefaultValue(false);
        builder.HasOne(e => e.Area).WithMany().HasForeignKey(e => e.AreaId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(e => e.Period).WithMany().HasForeignKey(e => e.PeriodId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(e => e.Perspective).WithMany().HasForeignKey(e => e.PerspectiveId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(e => e.GoalType).WithMany().HasForeignKey(e => e.GoalTypeId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(e => e.Project).WithMany().HasForeignKey(e => e.ProjectId).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(e => e.InitiativeEntities).WithOne(e => e.Goal).HasForeignKey(e => e.GoalId).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(e => e.Employee).WithMany().HasForeignKey(e => e.EmployeeId).OnDelete(DeleteBehavior.NoAction);
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