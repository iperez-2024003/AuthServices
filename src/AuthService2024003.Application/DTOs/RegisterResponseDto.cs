namespace AuthService2024003.Application.DTOs;

public class RegisterResponseDto
{
    public bool Sucess {get; set;} = false;
    public UserResponseDto User {get; set;} = new();
    public string Message {get; set;} = string.Empty;
    public bool EmailVerificationRequired {get; set;} = true;
    
}