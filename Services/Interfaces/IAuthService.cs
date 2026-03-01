using LeaveManagementSystem_Backend.DTO;

namespace LeaveManagementSystem_Backend.Services.Interfaces
{
    public interface IAuthService
    {
        string Register(RegisterDto dto);

        LoginResponseDto Login(LoginDto dto);
    }
}
