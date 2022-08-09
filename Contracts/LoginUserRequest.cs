using System.ComponentModel.DataAnnotations;

namespace FrontTest.Contracts
{
    public class LoginUserRequest
    {
        [Required]
        public string? Phone { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
