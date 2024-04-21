using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string FullName { get; set; }

        [Required]
        public string UserName { get; set; }

        public string PhoneNumber { get; set; }
    }
}
