namespace Domain.Entities.Book
{
    public sealed class BookCopy
    {
        private BookCopy()
        {
        }
        public BookCopy(BookCopyId id, BookId bookId, string barcode, string status, int shelfId)
        {
            Id = id;
            BookId = bookId;
            Barcode = barcode;
            Status = status;
            ShelfId = shelfId;
        }
        public BookCopyId Id { get; set; }
        public BookId BookId { get; set; }
        public string Barcode { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public int ShelfId { get; set; }
    }
}
