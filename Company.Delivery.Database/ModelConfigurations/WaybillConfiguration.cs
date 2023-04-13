using Company.Delivery.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.Delivery.Database.ModelConfigurations;

internal class WaybillConfiguration : IEntityTypeConfiguration<Waybill>
{
    public void Configure(EntityTypeBuilder<Waybill> builder)
    {
        // все строковые свойства должны иметь ограничение на длину
        // должно быть ограничение на уникальность свойства Waybill.Number
        // ApplicationDbContextTests должен выполняться без ошибок

        builder.Property(t => t.Number)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasIndex(e => e.Number, "UX_Waybill_Number")
            .IsUnique();


    }
}