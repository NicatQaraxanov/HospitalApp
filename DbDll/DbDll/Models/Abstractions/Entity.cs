using System.ComponentModel.DataAnnotations;

namespace DbDll.Models.Abstractions
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}
