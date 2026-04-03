using demo.proyect.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace demo.proyect_persistance.Configuration;

public class EmployeeEntityConfiguration : IEntityTypeConfiguration<EmployeeEntity>
{
    public void Configure(EntityTypeBuilder<EmployeeEntity> builder)
    {
        builder.ToTable("empleado", "dbo");
        builder.HasKey(e => e.AreaId);
        builder.Property(e => e.AreaId).ValueGeneratedOnAdd();
        builder.Property(e => e.FirtName).IsRequired().HasMaxLength(25);
        builder.Property(e => e.MiddleName).IsRequired().HasMaxLength(25);
        builder.Property(e => e.Surname).IsRequired().HasMaxLength(50);
        builder.Property(e => e.Code).IsRequired().HasMaxLength(6);
        builder.HasIndex(e => e.Code).IsUnique();
        builder.Property(e => e.CreatedBy).IsRequired(true).HasMaxLength(100);
        builder.Property(e => e.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("GETDATE()");
        builder.Property(e => e.UpdatedBy).IsRequired(false).HasMaxLength(100);
        builder.Property(e => e.UpdatedAt).ValueGeneratedOnUpdate().HasDefaultValueSql("GETDATE()");
        builder.Property(e => e.IsActive).HasDefaultValue(true);
        builder.Property(e => e.IsDeleted).HasDefaultValue(false);
        builder.Property(e => e.RowGuid).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
        builder.HasIndex(e => e.RowGuid).IsUnique();
        builder.HasOne(e => e.Area).WithMany().HasForeignKey(e => e.AreaId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.Position).WithMany().HasForeignKey(e => e.PositionId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(e => e.SuperiorEmployee).WithMany().HasForeignKey(e => e.SuperiorEmployeeId).OnDelete(DeleteBehavior.Restrict);
        builder.HasMany(e => e.GoalEntities).WithOne(g => g.Employee).HasForeignKey(g => g.EmployeeId).OnDelete(DeleteBehavior.Cascade);
        builder.Property(e => e.Gender).HasConversion<string>().HasMaxLength(10);
    }
}