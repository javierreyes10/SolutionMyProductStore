using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProductStore.Core.Entities;

namespace MyProductStore.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(u => u.Id);

            builder
                .Property(u => u.Id)
                .UseIdentityColumn();

            builder
                .Property(u => u.Name)
                .HasColumnName("Nombre")
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(u => u.Phone)
                .HasColumnName("Telefono")
                .IsRequired()
                .HasMaxLength(10);

            builder
                .Property(u => u.UserName)
                .HasColumnName("Usuario")
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(u => u.BirthdDate)
                .HasColumnName("FechaNacimiento")
                .IsRequired();

            builder
                .Property(u => u.Email)
                .HasColumnName("Email")
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(u => u.PasswordHash)
                .HasColumnName("PasswordHash")
                .IsRequired();

            builder
               .Property(u => u.ResetToken)
               .HasColumnName("ResetToken");

            builder
              .Property(u => u.ResetTokenExpires)
              .HasColumnName("ResetTokenExpires");

            builder
               .ToTable("Usuario");
        }
    }
}
