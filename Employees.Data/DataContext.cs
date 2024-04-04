using Employees.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Employees.Data
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<Company> Companies { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<EmployeePosition> EmployeePosition { get; set; }

        public DbSet<EmployeeTerms> EmployeeTerms { get; set; }

        public DbSet<AttendanceJournal> AttendanceJounals { get; set; }

        public DbSet<CompanyTerms> CompanyTerms { get; set; }

        public DbSet<BankAccount> BankAccounts { get; set; }

        public DbSet<Manager> Managers { get; set; }


        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration["ConnectionStrings:SqlConnectionString"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manager>().HasKey(m => m.CompanyId);
            modelBuilder.Entity<EmployeePosition>().HasKey(ec => new { ec.EmployeeId, ec.PositionId });

            
        }

    }
}
