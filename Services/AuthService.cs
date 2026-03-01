using LeaveManagementSystem_Backend.Data;
using LeaveManagementSystem_Backend.DTO;
using LeaveManagementSystem_Backend.Models;
using LeaveManagementSystem_Backend.Services.Interfaces;
using System.Linq;

namespace LeaveManagementSystem_Backend.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;

        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        public string Register(RegisterDto dto)
        {
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = dto.Password,
                Role = dto.Role
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return "User Registered Successfully";
        }

        public LoginResponseDto Login(LoginDto dto)
        {
            var user = _context.Users
                .FirstOrDefault(x => x.Email == dto.Email && x.Password == dto.Password);

            if (user == null)
                throw new Exception("Invalid Credentials");

            // Generate simple token
            var token = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{user.Id}:{user.Email}:{DateTime.UtcNow.Ticks}"));

            return new LoginResponseDto
            {
                Token = token,
                User = new
                {
                    id = user.Id,
                    name = user.Name,
                    email = user.Email,
                    role = user.Role
                }
            };
        }
    }
}