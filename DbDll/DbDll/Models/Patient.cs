using DbDll.Models.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace DbDll.Models
{
    public class Patient : Entity
    {
        [Required]
        public string Username { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public int Age { get; set; }

        public IList<DoctorPatients> DoctorPatients { get; set; } = new List<DoctorPatients>();
    }
}
