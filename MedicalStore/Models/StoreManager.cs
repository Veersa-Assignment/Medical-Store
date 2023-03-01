using System.ComponentModel.DataAnnotations;

namespace MedicalStore.Models
{
    public class StoreManager
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        public string Name { get; set; }
        public string Passwoord { get; set; }
        public DateTime CreatedDateTiem { get; set; } = DateTime.Now;
    }
}
