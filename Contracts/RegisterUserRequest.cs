using System.ComponentModel.DataAnnotations;

namespace FrontTest.Contracts
{
    public class RegisterUserRequest
    {
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Birth { get; set; }
        public string? Tg { get; set; }
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
    }
}
