using System.ComponentModel.DataAnnotations;

namespace MedicalStore.Models
{
    public class Billing
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
        public string MedicineName { get; set; }
        public int Quantity { get; set; }
       
    }
}
