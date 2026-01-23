using System.ComponentModel.DataAnnotations;

namespace AuthService2024003.Application.DTOs.Email;

public class ResendVerificationDto
{

    [Required]
    [EmailAddress]
    public string Email {get; set;} = string.Empty;
}