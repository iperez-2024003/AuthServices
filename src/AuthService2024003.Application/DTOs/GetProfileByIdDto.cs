using System.ComponentModel.DataAnnotations;

namespace AuthService2024003.Application.DTOs;

public class GetProfileByIdDto
{
    [Required(ErrorMessage = "El UserId es rwquerido")]
    public string UserId {get; set;} = string.Empty;

    



}