using System.ComponentModel.DataAnnotations;


namespace AuthService2024003.Application.DTOs;


public class ForgotPasswordDto
{
    [Required]
    [EmailAddress]
    public string Email {get; set;} = string.Empty;
}