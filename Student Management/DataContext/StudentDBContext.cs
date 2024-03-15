using Microsoft.EntityFrameworkCore;
using Student_Management.Models;

namespace Student_Management.DataContext
{
    public class StudentDBContext : DbContext
    {
        public StudentDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
    }
}
