namespace DTO
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Genre { get; set; }

        public DateTime PublicationYear { get; set; } = DateTime.Now;
        public string ISBN { get; set; }
        public decimal Price { get; set; } = decimal.Zero;
        public int Quantity { get; set; } = 0;
    }
}