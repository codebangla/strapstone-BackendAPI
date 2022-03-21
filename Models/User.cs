using System.ComponentModel.DataAnnotations;
namespace API.Models
{
    public class User
    {

        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [Required]
        public byte[] Password { get; set; }

        [Required]
        public byte[] PasswordKey { get; set; }
        public string Email { get; set; }
    }
}
