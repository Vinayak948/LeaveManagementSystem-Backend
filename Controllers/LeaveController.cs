using LeaveManagementSystem_Backend.DTO;
using LeaveManagementSystem_Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystem_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveController : ControllerBase
    {
        private readonly ILeaveService _leaveService;

        public LeaveController(ILeaveService leaveService)
        {
            _leaveService = leaveService;
        }

        // helper to parse user id header
        private int GetUserIdFromHeader()
        {
            if (Request.Headers.TryGetValue("X-User-Id", out var value) &&
                int.TryParse(value, out var id))
            {
                return id;
            }
            throw new InvalidOperationException("UserId header missing or invalid");
        }

        // POST: api/leave/apply
        [HttpPost("apply")]
        public IActionResult Apply(LeaveApplyDto dto)
        {
            var userId = GetUserIdFromHeader();
            _leaveService.ApplyLeave(userId, dto);
            return Ok("Leave Applied");
        }

        // GET: api/leave/my
        [HttpGet("my")]
        public IActionResult MyLeaves()
        {
            var userId = GetUserIdFromHeader();
            return Ok(_leaveService.GetUserLeaves(userId));
        }

        // GET: api/leave/summary
        [HttpGet("summary")]
        public IActionResult Summary()
        {
            var userId = GetUserIdFromHeader();
            return Ok(_leaveService.GetSummary(userId));
        }

        // GET: api/leave/all
        [HttpGet("all")]
        public IActionResult AllLeaves()
        {
            return Ok(_leaveService.GetAllLeaves());
        }

        // PUT: api/leave/update/{id}
        [HttpPut("update/{id}")]
        public IActionResult Update(int id, UpdateLeaveStatusDto dto)
        {
            _leaveService.UpdateStatus(id, dto.Status);
            return Ok("Updated");
        }
    }
}