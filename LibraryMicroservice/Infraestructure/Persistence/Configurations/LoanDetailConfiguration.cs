using Domain.Entities.Book;
using Domain.Entities.Loan;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Persistence.Configurations
{
    public class LoanDetailConfiguration : IEntityTypeConfiguration<LoanDetail>
    {
        public void Configure(EntityTypeBuilder<LoanDetail> builder)
        {
            builder.ToTable("LoanDetail");

            builder.HasKey(ld => new { ld.LoanId, ld.BookCopyId });

            builder.Property(ld => ld.LoanId)
                .HasConversion(id => id.Value, value => new LoanId(value))
                .IsRequired();

            builder.Property(ld => ld.BookCopyId)
                .HasConversion(id => id.Value, value => new BookCopyId(value))
                .IsRequired();
        }
    }
}
