using Company.Delivery.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.Delivery.Database.ModelConfigurations;

internal class CargoItemConfiguration : IEntityTypeConfiguration<CargoItem>
{
    public void Configure(EntityTypeBuilder<CargoItem> builder)
    {
        // все строковые свойства должны иметь ограничение на длину
        // должно быть ограничение на уникальность свойства CargoItem.Number в пределах одной сущности Waybill
        // ApplicationDbContextTests должен выполняться без ошибок

        builder.Property(t => t.Name)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(t => t.Number)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasIndex(e => e.Number, "UX_CargoItem_Number")
            .IsUnique();
    }
}