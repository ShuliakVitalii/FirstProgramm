using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Test3
{
    public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Заказы");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Date)
                .HasColumnName("Дата заказа")
                .HasColumnType("datetime2")
                .IsRequired();

            builder
                .Property(x => x.NumberOrders)
                .HasColumnName("Номер заказа")
                .IsRequired();

            builder
                .Property(x => x.FullNameClients)
                .HasColumnName("ФИО клиента")
                .IsRequired();

            builder
                .Property(x => x.TotalAmount)
                .HasColumnName("Общая сумма заказа")
                .HasColumnType("money")
                .IsRequired();

            builder
                .Property(x => x.ProductList)
                .HasColumnName("Список позиций заказа")
                .IsRequired();
        }
    }
}
