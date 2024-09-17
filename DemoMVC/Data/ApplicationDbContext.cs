using Microsoft.EntityFrameworkCore;
using DEMOMVC.Models;
namespace DEMOMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {}
        public DbSet<Employee> Employee { get; set; }
        
    }
}