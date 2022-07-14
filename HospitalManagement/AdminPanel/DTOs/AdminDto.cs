using System.ComponentModel.DataAnnotations;

namespace AdminPanel.DTOs
{
    public class AdminDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
