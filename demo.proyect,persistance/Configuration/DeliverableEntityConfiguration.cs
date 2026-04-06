using demo.proyect.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace demo.proyect_persistance.Configuration;

public class DeliverableEntityConfiguration : IEntityTypeConfiguration<DeliverableEntity>
{
    public void Configure(EntityTypeBuilder<DeliverableEntity> builder)
    {
        builder.ToTable("entregables", "dbo");
        builder.HasKey(e => e.DeliverableId);
        builder.Property(e => e.DeliverableId).ValueGeneratedOnAdd();
        builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
        builder.HasIndex(e => e.Name).IsUnique();
        builder.Property(e => e.Description).IsRequired(false).HasMaxLength(500);
        builder.Property(e => e.Ubication).IsRequired().HasMaxLength(250);
        builder.Property(e => e.CreatedBy).IsRequired(true).HasMaxLength(100);
        builder.Property(e => e.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("GETDATE()");
        builder.Property(e => e.UpdatedBy).IsRequired(false).HasMaxLength(100);
        builder.Property(e => e.UpdatedAt).ValueGeneratedOnUpdate().HasDefaultValueSql("GETDATE()");
        builder.Property(e => e.IsActive).HasDefaultValue(true);
        builder.Property(e => e.IsDeleted).HasDefaultValue(false);
        builder.Property(e => e.RowGuid).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
        builder.HasIndex(e => e.RowGuid).IsUnique();
        builder.HasOne(e => e.DeliverableType).WithMany().HasForeignKey(e => e.DeliverableTypeId);
    }
}