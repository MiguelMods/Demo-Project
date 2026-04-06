using demo.proyect.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace demo.proyect_persistance.Configuration;

public class GoalPeriodActionEntityConfiguration : IEntityTypeConfiguration<GoalPeriodActionEntity>
{
    public void Configure(EntityTypeBuilder<GoalPeriodActionEntity> builder)
    {
        builder.ToTable("objetivo_periodo_accion", "dbo");
        builder.HasKey(e => new { e.GoalId, e.PeriodId, e.StateId, e.ActionEntity  });
        builder.Property(e => e.CreatedBy).IsRequired(true).HasMaxLength(100);
        builder.Property(e => e.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("GETDATE()");
        builder.Property(e => e.UpdatedBy).IsRequired(false).HasMaxLength(100);
        builder.Property(e => e.UpdatedAt).ValueGeneratedOnUpdate().HasDefaultValueSql("GETDATE()");
        builder.Property(e => e.IsActive).HasDefaultValue(true);
        builder.Property(e => e.IsDeleted).HasDefaultValue(false);
        builder.Property(e => e.RowGuid).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
        builder.HasIndex(e => e.RowGuid).IsUnique();
        builder.HasOne(e => e.GoalEntity).WithMany().HasForeignKey(e => e.GoalId);
        builder.HasOne(e => e.PeriodEntity).WithMany().HasForeignKey(e => e.PeriodId);
        builder.HasOne(e => e.StateEntity).WithMany().HasForeignKey(e => e.StateId);
        builder.HasOne(e => e.ActionEntity).WithMany().HasForeignKey(e => e.ActionId);
        builder.Property(e => e.Sequence).IsRequired();
    }
}
