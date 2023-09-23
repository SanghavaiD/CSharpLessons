using System.ComponentModel.DataAnnotations;

namespace MyFirstMCPApp.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength (3, ErrorMessage="Enter characters between 3 to 30")]
        public String Name { get; set; } = string.Empty;
        [Range (10000,500000)]
        public decimal  Salary { get; set; }
        [Required]
        public string City { get; set; }=string.Empty;

    }
}
