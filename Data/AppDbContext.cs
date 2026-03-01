using LeaveManagementSystem_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem_Backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
    }
}
