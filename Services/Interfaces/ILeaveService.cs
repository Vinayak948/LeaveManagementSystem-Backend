using LeaveManagementSystem_Backend.DTO;

namespace LeaveManagementSystem_Backend.Services.Interfaces
{
    public interface ILeaveService
    {
        void ApplyLeave(int userId, LeaveApplyDto dto);
        List<object> GetUserLeaves(int userId);
        List<object> GetAllLeaves();
        object GetSummary(int userId);
        void UpdateStatus(int leaveId, string status);
    }
}
