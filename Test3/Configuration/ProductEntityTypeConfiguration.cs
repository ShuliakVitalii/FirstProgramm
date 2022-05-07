using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Test3
{
    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Продукты");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Price)
                .HasColumnName("Цена")
                .HasColumnType("money")
                .IsRequired();

            builder
                .Property(x => x.Quantity)
                .HasColumnName("Количетсво")
                .IsRequired();

            builder
                .Property(x => x.Value)
                .HasColumnName("Стоимость")
                .HasComputedColumnSql("[Цена] * [Количетсво]");

            builder
            .HasOne(t => t.Order)
            .WithOne(t => t.Product)
            .HasForeignKey<Order>(t => t.ProductId);
        }
    }
}
