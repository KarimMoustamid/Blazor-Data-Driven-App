namespace WiredBrainCoffee.EmployeeManager.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Reflection.Metadata.Ecma335;

    public class Department
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        public List<Employee> Employees { get; set; }
    }
}