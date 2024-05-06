namespace WiredBrainCoffee.EmployeeManager.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string? LastName { get; set; }

        public bool IsDeveloper { get; set; }

        public Department? Department { get; set; }

        [Required]
        public int? DepartmentId { get; set; }
    }
}