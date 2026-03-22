using demo.proyect.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace demo.proyect_persistance.Configuration;

public class PriorityTypeEntityConfiguration : IEntityTypeConfiguration<PriorityTypeEntity> 
{
    public void Configure(EntityTypeBuilder<PriorityTypeEntity> builder)
    {
        builder.ToTable("prj_tipo_prioridad", "dbo");
        builder.HasKey(e => e.PriorityTypeId);
        builder.Property(e => e.PriorityTypeId).ValueGeneratedOnAdd();
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
            new()
            {
                PriorityTypeId = 1,
                Name = "best effort",
                Description = "best effort",
                CreatedBy = "seed-on-proyect"
            },
            new()
            {
                PriorityTypeId = 2,
                Name = "time sensitive",
                Description = "time sensitive",
                CreatedBy = "seed-on-proyect"
            },
            new()
            {
                PriorityTypeId = 3,
                Name = "top priority",
                Description = "top priority",
                CreatedBy = "seed-on-proyect"
            }
            ]);
    }
}