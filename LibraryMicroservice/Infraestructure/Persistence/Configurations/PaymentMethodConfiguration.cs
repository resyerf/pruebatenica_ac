using Domain.Entities.PaymentMethod;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Persistence.Configurations
{
    public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.ToTable("PaymentMethod");
            builder.HasKey(pm => pm.Id);
            builder.Property(pm => pm.Id)
                .HasConversion(id => id.Value, value => new PaymentMethodId(value));
            builder.Property(pm => pm.nombre)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
