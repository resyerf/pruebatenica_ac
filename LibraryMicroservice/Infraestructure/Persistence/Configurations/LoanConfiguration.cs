using Domain.Entities.Loan;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Persistence.Configurations
{
    public class LoanConfiguration : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.ToTable("Loan");
            builder.HasKey(pm => pm.Id);

            builder.Property(pm => pm.Id)
                .HasConversion(
                id => id.Value, 
                value => new LoanId(value));

            builder.Property(pm => pm.ClientId);
            builder.Property(pm => pm.StartDate)
                .IsRequired();
           builder.Property(pm => pm.EndDate)
                .IsRequired(false);
            builder.Property(pm => pm.Status)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(pm => pm.PaymentMethodId)
                .IsRequired(false);
        }
    }
}
