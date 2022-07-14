using DbDll.Models.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace DbDll.Models
{
    public class Admin : Entity
    {
        [Required]
        public string Username { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

    }
}
