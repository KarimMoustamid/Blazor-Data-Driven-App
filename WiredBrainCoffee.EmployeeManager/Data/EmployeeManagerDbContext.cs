namespace WiredBrainCoffee.EmployeeManager.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class EmployeeManagerDbContext : DbContext
    {
        public EmployeeManagerDbContext(DbContextOptions<EmployeeManagerDbContext> options) : base(options)
        {
        }

        //NOTE : public DbSet<Employee> Employees { get; set; } , the recommended way to write this prop without the null warning is via an expression body :
        public DbSet<Employee> Employees => this.Set<Employee>();

        public DbSet<Department> Departments => this.Set<Department>();
    }
}