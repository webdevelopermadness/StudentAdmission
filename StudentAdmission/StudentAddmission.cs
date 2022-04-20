using System.ComponentModel.DataAnnotations;

namespace StudentAdmission
{
    public class StudentAddmission
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Address { get; set; } = String.Empty;
        [Required]
        public int Age { get; set; }
    }
}
