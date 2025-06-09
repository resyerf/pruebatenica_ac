using Domain.Entities.Book;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Persistence.Configurations
{
    public class BookCopyConfiguration : IEntityTypeConfiguration<BookCopy>
    {
        public void Configure(EntityTypeBuilder<BookCopy> builder)
        {
            builder.ToTable("BookCopy");
            builder.HasKey(bc => bc.Id);

            builder.Property(bc => bc.Id)
                .HasConversion(id => id.Value, value => new BookCopyId(value));

            builder.Property(bc => bc.BookId)
                .HasConversion(id => id.Value, value => new BookId(value))
                .IsRequired();

            builder.Property(bc => bc.Barcode)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(bc => bc.Status)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(bc => bc.ShelfId)
                .IsRequired();
        }
    }
}
