using demo.proyect.domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace demo.proyect_persistance.Configuration;

public class UsersProfilesEntityConfiguration : IEntityTypeConfiguration<UsersProfilesEntity>
{
    public void Configure(EntityTypeBuilder<UsersProfilesEntity> builder)
    {
        builder.ToTable("usuarios_perfiles", "dbo");
        builder.HasKey(e => new { e.UserId, e.ProfileId });
        builder.HasOne(e => e.User).WithMany(e => e.UsersProfilesEntities).HasForeignKey(e => e.UserId);
        builder.HasOne(e => e.Profile).WithMany(e => e.UsersProfilesEntities).HasForeignKey(e => e.ProfileId);
        builder.Property(e => e.CreatedBy).IsRequired(true).HasMaxLength(100);
        builder.Property(e => e.CreatedAt).ValueGeneratedOnAdd().HasDefaultValueSql("GETDATE()");
        builder.Property(e => e.UpdatedBy).IsRequired(false).HasMaxLength(100);
        builder.Property(e => e.UpdatedAt).ValueGeneratedOnUpdate().HasDefaultValueSql("GETDATE()");
        builder.Property(e => e.IsActive).HasDefaultValue(true);
        builder.Property(e => e.IsDeleted).HasDefaultValue(false);
        builder.Property(e => e.RowGuid).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
        builder.HasIndex(e => e.RowGuid).IsUnique();
        builder.HasData([
                new() { UserId = 1, ProfileId = 1, CreatedBy = "system" },
            ]);
    }
}