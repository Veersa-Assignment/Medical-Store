using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalStore.Models
{
    public class StoreManager
    {
       
        [Key]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDateTiem { get; set; } = DateTime.Now;
        public string role { get; set; }
        [NotMapped]
        public List<SelectListItem> Inventories { set; get; }

    }
}
