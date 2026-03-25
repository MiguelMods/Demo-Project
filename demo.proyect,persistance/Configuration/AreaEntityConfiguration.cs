using demo.proyect.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace demo.proyect_persistance.Configuration;

public class AreaEntityConfiguration : IEntityTypeConfiguration<AreaEntity>
{
    public void Configure(EntityTypeBuilder<AreaEntity> builder)
    {
        builder.ToTable("areas", "dbo");
        builder.HasKey(e => e.AreaId);
        builder.Property(e => e.AreaId).ValueGeneratedOnAdd();
        builder.Property(e => e.Code).IsRequired().HasMaxLength(3);
        builder.HasIndex(e => e.Code).IsUnique();
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
        builder.HasOne(e => e.SuperiorAreaEntity).WithMany(e => e.SubAreasEntities).HasForeignKey(e => e.SuperiorAreaId).OnDelete(DeleteBehavior.Restrict);
    }   
}