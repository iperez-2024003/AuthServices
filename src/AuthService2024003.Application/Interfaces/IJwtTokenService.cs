using AuthService2024003.Domain.Entities;

namespace AuthService2024003.Application.Interfaces;

public interface IJwtTokenService
{
    string GenerateToken (User user);
}