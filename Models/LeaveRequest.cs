using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementSystem_Backend.Models
{
    public class LeaveRequest
    {
        public int Id { get; set; }

        [Required]
        public DateTime FromDate { get; set; }

        [Required]
        public DateTime ToDate { get; set; }

        public string? Reason { get; set; }

        public string? Status { get; set; } = "Pending";

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }
    }
}
