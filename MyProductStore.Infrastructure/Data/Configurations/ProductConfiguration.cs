using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyProductStore.Core.Entities;

namespace MyProductStore.Infrastructure.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Id)
                .UseIdentityColumn();

            builder
                .Property(p => p.Name)
                .HasColumnName("Nombre")
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(p => p.Quantity)
                .HasColumnName("Cantidad")
                .IsRequired();

            builder
               .Property(p => p.Price)
               .HasColumnName("Precio")
               .IsRequired();

            builder
                .Property(p => p.Description)
                .HasColumnName("Descripcion")
                .HasMaxLength(250);

            builder
                .Property(p => p.Image)
                .HasColumnName("Imagen")
                .HasMaxLength(500)
                .IsUnicode(false);

            builder
                .Property(p => p.SKU)
                .HasMaxLength(20)
                .IsUnicode(false);

            builder
               .ToTable("Producto");
        }
    }
}
