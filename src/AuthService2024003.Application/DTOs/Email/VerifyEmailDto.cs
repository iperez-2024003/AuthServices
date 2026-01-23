using System.ComponentModel.DataAnnotations;

namespace AuthService2024003.Application.DTOs.Email;

public class VerifyEmailDto
{
    [Required]
    
    public string Token {get; set;} = string.Empty;

}