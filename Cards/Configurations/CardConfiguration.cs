using Cards.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cards.Configurations;

public class CardConfiguration : IEntityTypeConfiguration<Card>
{
    public void Configure(EntityTypeBuilder<Card> builder)
    {
        builder.Property(c => c.Color)
            .HasMaxLength(7)
            .IsRequired();

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(c => c.Description)
            .HasMaxLength (255);

        builder.Property(c => c.Status)
            .IsRequired()
            .HasMaxLength(15);

        builder.HasOne(u => u.User)
            .WithMany(c => c.Cards)
            .HasForeignKey(u => u.UserId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
    }
}

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.HasIndex(c => c.EmailAddress)
            .IsUnique();
        builder.Property(c=>c.EmailAddress)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(c=>c.Password)
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(c=>c.Role)
            .IsRequired()
            .HasMaxLength(20);

    }
}