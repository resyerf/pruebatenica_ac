using Domain.Primitives;

namespace Domain.Entities.Book
{
    public sealed class Book : AggregateRoot
    {
        private Book()
        {
        }

        public Book(BookId id, string title, string author, string category, string description, double salePrice, double rentalPrice)
        {
            Id = id;
            Title = title;
            Author = author;
            Category = category;
            Description = description;
            SalePrice = salePrice;
            RentalPrice = rentalPrice;
        }

        public BookId Id { get; private set; }
        public string Title { get; private set; } = string.Empty;
        public string Author { get; private set; } = string.Empty;
        public string Category { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public double SalePrice { get; private set; } = 0.0;
        public double RentalPrice { get; private set; } = 0.0;
    }
}
