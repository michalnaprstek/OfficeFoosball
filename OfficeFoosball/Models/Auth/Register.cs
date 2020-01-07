using System.ComponentModel.DataAnnotations;

namespace OfficeFoosball.Models.Auth
{
    public class Register
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string AccessCode { get; set; }
    }
}
