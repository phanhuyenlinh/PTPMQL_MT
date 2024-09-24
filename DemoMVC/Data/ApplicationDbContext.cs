using Microsoft.EntityFrameworkCore;
using DEMOMVC.Models;
using MVC.Models;
namespace DEMOMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {}
        public DbSet<Employee> Employee { get; set; }
        public DbSet<SinhVien> SinhVien { get; set; }
    }
}