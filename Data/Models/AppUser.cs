using System.ComponentModel.DataAnnotations;

namespace FrontTest.Data.Models
{
    public class AppUser
    {
        public Guid Id { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Число символов в поле должно быть от 1 до 20")]
        public string? Name { get; set; }
        [Required]
        public string? Birth { get; set; }
        public string? Tg { get; set; }
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
    }
}
