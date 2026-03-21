using demo.proyect.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace demo.proyect_persistance.Configuration;

public class ProjectEntityConfiguration : IEntityTypeConfiguration<ProjectEntity>
{
    public void Configure(EntityTypeBuilder<ProjectEntity> builder)
    {
        builder.ToTable("prj_proyecto", "dbo");
        builder.HasKey(e => e.ProjectId);
        builder.Property(e => e.CodeOne).IsRequired().HasMaxLength(6);
        builder.HasIndex(e => e.CodeOne).IsUnique();
        builder.Property(e => e.CodeTwo).HasMaxLength(20);
        builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
        builder.HasIndex(e => e.Name).IsUnique();
        builder.Property(e => e.Objetive).HasMaxLength(500);
        builder.Property(e => e.Scope).HasMaxLength(500);
        builder.Property(e => e.Description).HasMaxLength(500);
        builder
     .HasOne(e => e.Area)
     .WithMany()
     .HasForeignKey(e => e.AreaId)
     .OnDelete(DeleteBehavior.Restrict);
        builder
    .HasOne(e => e.SubArea)
    .WithMany()
    .HasForeignKey(e => e.SubAreaId)
    .OnDelete(DeleteBehavior.Restrict);
        builder.Property(e => e.PoaRoadmap).HasDefaultValue(false);
        builder.Property(e => e.EnterDate);
        builder.Property(e => e.WishDate);
        builder.Property(e => e.IsCritical).HasDefaultValue(false);
        builder.Property(e => e.UseNormalFlow).HasDefaultValue(false);
        builder.HasOne(e => e.Priority).WithOne().HasForeignKey<PriorityTypeEntity>(a => a.PriorityTypeId);
        builder.HasOne(e => e.ProjectType).WithOne().HasForeignKey<ProjectTypeEntity>(a => a.ProjectTypeId);
        builder.HasOne(e => e.ProjectDevelopmentType).WithOne().HasForeignKey<ProjectDevelopmentTypeEntity>(a => a.ProjectDevelopmentTypeId);
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