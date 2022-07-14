using System.ComponentModel.DataAnnotations;

namespace UserPanel.DTOs
{
    public class UserDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Range(1, 130, ErrorMessage = "Age must be between 1 and 130 only!!")]
        [Required]
        public int Age { get; set; }
    }
}
