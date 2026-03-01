using LeaveManagementSystem_Backend.Data;
using LeaveManagementSystem_Backend.DTO;
using LeaveManagementSystem_Backend.Models;
using LeaveManagementSystem_Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem_Backend.Services
{
    public class LeaveService : ILeaveService
    {
        private readonly AppDbContext _context;

        public LeaveService(AppDbContext context)
        {
            _context = context;
        }

        public void ApplyLeave(int userId, LeaveApplyDto dto)
        {
            var leave = new LeaveRequest
            {
                FromDate = dto.FromDate,
                ToDate = dto.ToDate,
                Reason = dto.Reason,
                UserId = userId,
                Status = "Pending"
            };

            _context.LeaveRequests.Add(leave);
            _context.SaveChanges();
        }

        public List<object> GetUserLeaves(int userId)
        {
            return _context.LeaveRequests
                .Where(l => l.UserId == userId)
                .Include(l => l.User)
                .Select(l => new
                {
                    l.Id,
                    employeeName = l.User.Name,
                    startDate = l.FromDate.ToString("yyyy-MM-dd"),
                    endDate = l.ToDate.ToString("yyyy-MM-dd"),
                    l.Reason,
                    l.Status
                }).ToList<object>();
        }

        public List<object> GetAllLeaves()
        {
            return _context.LeaveRequests
                .Include(l => l.User)
                .Select(l => new
                {
                    l.Id,
                    employeeName = l.User.Name,
                    startDate = l.FromDate.ToString("yyyy-MM-dd"),
                    endDate = l.ToDate.ToString("yyyy-MM-dd"),
                    l.Reason,
                    l.Status,
                    l.UserId
                }).ToList<object>();
        }

        public void UpdateStatus(int leaveId, string status)
        {
            var leave = _context.LeaveRequests.Find(leaveId);
            leave.Status = status;
            _context.SaveChanges();
        }

        public object GetSummary(int userId)
        {
            var userLeaves = _context.LeaveRequests.Where(l => l.UserId == userId).ToList();
            return new
            {
                total = userLeaves.Count,
                pending = userLeaves.Count(l => l.Status == "Pending"),
                approved = userLeaves.Count(l => l.Status == "Approved"),
                rejected = userLeaves.Count(l => l.Status == "Rejected")
            };
        }
    }
}
