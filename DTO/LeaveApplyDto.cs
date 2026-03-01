namespace LeaveManagementSystem_Backend.DTO
{
    public class LeaveApplyDto
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string? Reason { get; set; }
    }
}
