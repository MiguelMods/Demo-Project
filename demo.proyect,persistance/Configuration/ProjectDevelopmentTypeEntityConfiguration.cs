using demo.proyect.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace demo.proyect_persistance.Configuration;

public class ProjectDevelopmentTypeEntityConfiguration : IEntityTypeConfiguration<ProjectDevelopmentTypeEntity>
{
    public void Configure(EntityTypeBuilder<ProjectDevelopmentTypeEntity> builder)
    {
        builder.ToTable("prj_tipo_ejecucion", "dbo");
        builder.HasKey(e => e.ProjectDevelopmentTypeId);
        builder.Property(e => e.ProjectDevelopmentTypeId).ValueGeneratedOnAdd();
        builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
        builder.HasIndex(e => e.Name).IsUnique();
        builder.Property(e => e.Description).HasMaxLength(500);
        builder.Property(e => e.CreatedBy).IsRequired(true).HasMaxLength(100);
        builder.Property(e => e.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("GETDATE()");
        builder.Property(e => e.UpdatedBy).IsRequired(false).HasMaxLength(100);
        builder.Property(e => e.UpdatedAt).ValueGeneratedOnUpdate().HasDefaultValueSql("GETDATE()");
        builder.Property(e => e.IsActive).HasDefaultValue(true);
        builder.Property(e => e.IsDeleted).HasDefaultValue(false);
        builder.Property(e => e.RowGuid).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
        builder.HasIndex(e => e.RowGuid).IsUnique();
        builder.HasData([
            new(){ ProjectDevelopmentTypeId = 1, Name = "fast track", Description = "fast track", CreatedBy = "me" },
            new(){ ProjectDevelopmentTypeId = 2, Name = "super fast track", Description = "super fast track", CreatedBy = "me" },
            new(){ ProjectDevelopmentTypeId = 3, Name = "full track", Description = "full track", CreatedBy = "me" },
            ]);
    }
}
