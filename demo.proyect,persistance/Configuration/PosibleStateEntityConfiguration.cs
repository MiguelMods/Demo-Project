using demo.proyect.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace demo.proyect_persistance.Configuration;

public class PosibleStateEntityConfiguration : IEntityTypeConfiguration<PosibleStateEntity>
{
    public void Configure(EntityTypeBuilder<PosibleStateEntity> builder)
    {
        builder.ToTable("posible_elemento_periodo_estado", "dbo");
        builder.HasKey(e => new { e.ElementTypeId, e.PeriodId, e.StateId });
        builder.Property(e => e.MinimumValue).IsRequired();
        builder.Property(e => e.MaximumValue).IsRequired();
        builder.Property(e => e.CreatedBy).IsRequired(true).HasMaxLength(100);
        builder.Property(e => e.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("GETDATE()");
        builder.Property(e => e.UpdatedBy).IsRequired(false).HasMaxLength(100);
        builder.Property(e => e.UpdatedAt).ValueGeneratedOnUpdate().HasDefaultValueSql("GETDATE()");
        builder.Property(e => e.IsActive).HasDefaultValue(true);
        builder.Property(e => e.IsDeleted).HasDefaultValue(false);
        builder.Property(e => e.RowGuid).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
        builder.HasIndex(e => e.RowGuid).IsUnique();
        builder.HasOne(e => e.ElementType).WithMany().HasForeignKey(e => e.ElementTypeId);
        builder.HasOne(e => e.PeriodEntity).WithMany().HasForeignKey(e => e.PeriodId);
        builder.HasOne(e => e.StateEntity).WithMany().HasForeignKey(e => e.StateId);
    }
}