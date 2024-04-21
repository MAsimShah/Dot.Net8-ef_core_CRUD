using System.ComponentModel.DataAnnotations;

namespace DomainEntities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Publisher { get; set; }

        [Required]
        public string Genre { get; set; }

        public DateTime PublicationYear { get; set; } = DateTime.Now;

        public string ISBN { get; set; }

        public decimal Price { get; set; } = decimal.Zero;

        public int Quantity { get; set; } = 0;
    }
}