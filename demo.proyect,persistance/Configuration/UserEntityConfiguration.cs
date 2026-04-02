using demo.proyect.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace demo.proyect_persistance.Configuration;

public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("usuarios", "dbo");
        builder.HasKey(e => e.UserId);
        builder.Property(e => e.UserId).ValueGeneratedOnAdd();
        builder.Property(e => e.UserName).IsRequired().HasMaxLength(50);
        builder.HasIndex(e => e.UserName).IsUnique();
        builder.Property(e => e.Password).IsRequired().HasMaxLength(25);
        builder.Property(e => e.AskForNewPassword).HasDefaultValue(false);
        builder.Property(e => e.IsBloked).HasDefaultValue(false);
        builder.Property(e => e.CreatedBy).IsRequired(true).HasMaxLength(100);
        builder.Property(e => e.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("GETDATE()");
        builder.Property(e => e.UpdatedBy).IsRequired(false).HasMaxLength(100);
        builder.Property(e => e.UpdatedAt).ValueGeneratedOnUpdate().HasDefaultValueSql("GETDATE()");
        builder.Property(e => e.IsActive).HasDefaultValue(true);
        builder.Property(e => e.IsDeleted).HasDefaultValue(false);
        builder.Property(e => e.RowGuid).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
        builder.HasIndex(e => e.RowGuid).IsUnique();
        builder.HasData([
                new() {UserId = 1, UserName = "administrator", Password = "@dministrator", CreatedBy = "system" },
            ]);
    }
}