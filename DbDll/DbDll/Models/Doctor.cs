using DbDll.Models.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace DbDll.Models
{
    public class Doctor : Entity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        [Range(19, 99, ErrorMessage = "Age must be between 18 and 100 only!!")]
        public int Age { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        [Range(1, 99, ErrorMessage = "Experience must be between 1 and 100 only!!")]
        public int Experience { get; set; }

        public IList<DoctorPatients> DoctorPatients { get; set; } = new List<DoctorPatients>();

    }
}
